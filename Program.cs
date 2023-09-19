using HillaryHairCare.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HillaryHairCareDbContext>(builder.Configuration["HillaryHairCareDbConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// add endoints here 

//first basic get everything.
app.MapGet("/api/stylists", (HillaryHairCareDbContext db) =>
{
    return db.Stylists.OrderBy(a => a.Id).ToList();
});
app.MapGet("/api/customers", (HillaryHairCareDbContext db) =>
{
    return db.Customers.OrderBy(a => a.Id).ToList();
});
app.MapGet("/api/appointments", (HillaryHairCareDbContext db) =>
{
    return db.Appointments
    .Include(a => a.Stylist)
    .Include(a => a.Customer)
    .Include(a => a.Services)
    .OrderBy(a => a.Id)
    .ToList();
});
app.MapGet("/api/services", (HillaryHairCareDbContext db) =>
{
    return db.Services.OrderBy(a => a.Id).ToList();
});
//post a new customer 
app.MapPost("/api/customers", (HillaryHairCareDbContext db, Customer customer) =>
{
    //first make sure that the customer name is not an empty string
    if (customer.Name == "" || customer.Name == " "){
        return Results.BadRequest();
    }
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.Ok(customer);
});

//post a new stylist
app.MapPost("/api/stylists", (HillaryHairCareDbContext db, Stylist stylist ) =>
{
    //first make sure that the customer name is not an empty string
    if (stylist.Name == "" || stylist.Name == " "){
        return Results.BadRequest();
    }
    db.Stylists.Add(stylist);
    db.SaveChanges();
    return Results.Ok(stylist);
});

//activate a stylist
app.MapPut("/api/stylists/{id}/activate", (HillaryHairCareDbContext db, int id) =>
{
    //get the specific stylist we are activating. 
    Stylist stylist = db.Stylists.SingleOrDefault(s => s.Id == id);
    if (stylist == null)
    {
        return Results.NotFound();
    }
    stylist.IsActive = true;
    db.SaveChanges();
    return Results.Ok(stylist);
});
//deactivate a stylist
app.MapPut("/api/stylists/{id}/deactivate", (HillaryHairCareDbContext db, int id) =>
{
    //get the specific stylist we are activating. 
    Stylist stylist = db.Stylists.SingleOrDefault(s => s.Id == id);
    if (stylist == null)
    {
        return Results.NotFound();
    }
    stylist.IsActive = false;
    db.SaveChanges();
    return Results.Ok(stylist);
});


app.MapPut("/api/appointmentservices/{id}", (HillaryHairCareDbContext db, int id, Appointment appointment) =>
{
    //creates a list of all the new service ids. 
    var ids = appointment.Services.Select(s => s.Id).ToList();
    //creates a list of all the new service objects
    var matches = db.Services.Where((s) => ids.Contains(s.Id)).ToList();
    //this gets us the appointment we are updating. 
    var appointmentToUpdate = db.Appointments.Include(a => a.Services).FirstOrDefault((app) => app.Id == appointment.Id);
    // clears the current list of services
    appointmentToUpdate.Services.Clear();
    //updates with the new services.
    appointmentToUpdate.Services = matches;
    db.SaveChanges();

    return Results.NoContent(); // Return a 204 No Content response after deletion
});

app.MapPost("/api/appointments", (HillaryHairCareDbContext db, Appointment appointment) =>
{
    var ids = appointment.Services.Select(s => s.Id).ToList();

    var matches = db.Services.Where((s) => ids.Contains(s.Id)).ToList();

    appointment.Services.Clear();

    appointment.Services = matches;

    db.Appointments.Add(appointment);
    
    db.SaveChanges();

    return Results.Ok();
}); 

app.MapDelete("/api/appointments/{id}", (HillaryHairCareDbContext db, int id) =>{
    var appointmentToDelete = db.Appointments.FirstOrDefault((a) => a.Id == id);
    db.Appointments.Remove(appointmentToDelete);
    db.SaveChanges();
    return Results.NoContent();
});

app.Run();

