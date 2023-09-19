import { useEffect, useState } from "react";
import {
 Button,
 Card,
 CardBody,
 CardSubtitle,
 CardText,
 CardTitle,
} from "reactstrap";
import { deleteAppointment, updateService } from "../../Data/appointmentData";

export const AppointmentCard = ({ appointment, services, getData }) => {
 const [selectedServices, setSelectedServices] = useState([]);

 //inital render of matching servies
 useEffect(() => {
  setSelectedServices(appointment.services);
 }, []);

 //handle the checkbox changes
 const handleCheckboxCheck = (e, s) => {
  const { checked } = e.target;
  let clone = structuredClone(selectedServices);
  if (checked) {
   clone.push(structuredClone(s));
  } else {
   clone = clone.filter((serv) => serv.id !== s.id);
  }
  setSelectedServices(clone);
 };

 //function to handle the submit
 const handleSubmit = () => {
  let clone = structuredClone(appointment);
  clone.services = structuredClone(selectedServices);
  updateService(appointment.id, clone).then(() => getData());
 };
 if (!appointment) {
  return "";
 }

 return (
  <Card className="appoinmentCard" color="primary" outline>
   <CardBody>
    <CardTitle tag="h5">
     Date: {appointment?.appointmentTime?.split("T")[0]}
    </CardTitle>
    <CardSubtitle className="mb-2 text-muted" tag="h6">
     Time: {appointment?.appointmentTime?.slice(11, 16)}
    </CardSubtitle>
    <CardSubtitle className="mb-2" tag="h6">
     Stylist: {appointment?.stylist?.name}
    </CardSubtitle>
    <CardSubtitle className="mb-2" tag="h6">
     Customer: {appointment?.customer?.name}
    </CardSubtitle>
    <CardText>Services</CardText>
    <div>
     {services.map((service) => {
      return (
       <div key={service.id}>
        <input
         type="checkbox"
         id={`service-${service.id}`}
         checked={!!selectedServices.find((s) => s.id === service.id)}
         onChange={(e) => {
          handleCheckboxCheck(e, service);
         }}
        />
        <label>{service?.name}</label>
       </div>
      );
     })}
    </div>
    <div id="appointmentCardButtonContainer">
     <Button
      onClick={() => {
       deleteAppointment(appointment.id).then(() => getData());
      }}
     >
      Delete
     </Button>

     <Button onClick={handleSubmit}>Submit Changes</Button>
    </div>
    <h1>Total: {appointment.totalCost}</h1>
   </CardBody>
  </Card>
 );
};
