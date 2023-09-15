using Microsoft.EntityFrameworkCore;
using HillaryHairCare.Models;

public class HillaryHairCareDbContext : DbContext
{

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }

    public HillaryHairCareDbContext(DbContextOptions<HillaryHairCareDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // seed data with campsite types
    modelBuilder.Entity<Customer>().HasData(new Customer[]
    {
        new Customer {Id = 1, Name = "Kai Sa"},
        new Customer {Id = 2, Name = "Yuumi"},
        new Customer {Id = 3, Name = "Tahm Kench"},
        new Customer {Id = 4, Name = "Janna"},
        new Customer {Id = 5, Name = "Reneketon"},
        new Customer {Id = 6, Name = "Ashe"},
    });


    modelBuilder.Entity<Stylist>().HasData(new Stylist[]
    {
        new Stylist {Id = 1, Name = "Marissa Sullivan", IsActive = true},
        new Stylist {Id = 2, Name = "Joseph Pearson", IsActive = true},
        new Stylist {Id = 3, Name = "Chris Mills", IsActive = false},
        new Stylist {Id = 4, Name = "David TankTop", IsActive = true},
        new Stylist {Id = 5, Name = "Deanna David", IsActive = false},
     
    });

    modelBuilder.Entity<Service>().HasData(new Service[]
    {
      new Service {Id =1, Name = "Basic Wash", ServiceRate = 15.99M},
      new Service {Id =2, Name = "You Stinky Wash", ServiceRate = 25.99M},
      new Service {Id =3, Name = "Green Dye", ServiceRate = 22.49M},
      new Service {Id =4, Name = "Quick Cut", ServiceRate = 19.99M},
      new Service {Id =5, Name = "Total Makeover", ServiceRate = 74.99M},
      new Service {Id =6, Name = "Kid Clip", ServiceRate = 7.99M},
    });

    modelBuilder.Entity<Appointment>().HasData(new Appointment[]
    {
      new Appointment {Id =1, StylistId = 2, CustomerId = 5, AppointmentTime = new DateTime(2023,9,15,8,0,0)},
      new Appointment {Id =2, StylistId = 3, CustomerId = 2, AppointmentTime = new DateTime(2023,9,15,9,0,0)},
      new Appointment {Id =3, StylistId = 1, CustomerId = 3, AppointmentTime = new DateTime(2023,9,15,14,0,0)},
      new Appointment {Id =4, StylistId = 4, CustomerId = 1, AppointmentTime = new DateTime(2023,9,15,15,0,0)},
      new Appointment {Id =5, StylistId = 5, CustomerId = 6, AppointmentTime = new DateTime(2023,9,15,13,0,0)}
    });

    modelBuilder.Entity("AppointmentService").HasData(new object[]
{
    new {AppointmentsId = 1, ServicesId = 1},
    new {AppointmentsId = 1, ServicesId = 3},
    new {AppointmentsId = 2, ServicesId = 2},
    new {AppointmentsId = 2, ServicesId = 3},
    new {AppointmentsId = 3, ServicesId = 1},
    new {AppointmentsId = 4, ServicesId = 4}
});
}




}