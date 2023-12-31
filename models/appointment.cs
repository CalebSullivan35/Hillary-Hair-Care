using System.ComponentModel.DataAnnotations;
namespace HillaryHairCare.Models;
public class Appointment
{
  public int Id { get; set;}
  public int StylistId { get; set; }
  public Stylist Stylist { get; set; }
  public int CustomerId { get; set; }
  public Customer Customer { get; set; }
  public DateTime AppointmentTime { get; set; }
  public List<Service>? Services { get; set; }

  public decimal? TotalCost {
    get
    {
      decimal? totalPrice = 0M;
      if (Services != null)
      {
        foreach (Service service in Services)
        {
          totalPrice += service.ServiceRate;
        };
      }
      return totalPrice;
    }
  }
 }