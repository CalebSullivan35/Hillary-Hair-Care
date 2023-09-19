import React, { useState } from "react";
import {
 Button,
 Modal,
 ModalHeader,
 ModalBody,
 ModalFooter,
 Input,
 Label,
 CardText,
} from "reactstrap";
import { postAppointment } from "../../Data/appointmentData";

function AppointmentCreateModal({ services, customers, stylists, getData }) {
 const [modal, setModal] = useState(false);
 const [newAppointment, setNewAppointment] = useState({
  selectedServices: [],
  stylistId: null,
  customerId: null,
  appointmentTime: null,
 });

 const [appointmentDate, setAppointmentDate] = useState();
 const [appointmentTime, setAppointmentTime] = useState();

 const toggle = () => setModal(!modal);

 // handle the checkboxchanges
 const handleCheckboxCheck = (e, s) => {
  const { checked } = e.target;
  let clone = structuredClone(newAppointment);
  console.log(clone.selectedServices);
  if (checked) {
   clone.selectedServices.push(s);
  } else {
   clone.selectedServices = clone.selectedServices.filter(
    (serv) => serv.id !== s.id
   );
  }
  setNewAppointment(clone);
 };

 //handle the submit
 const handleSubmit = () => {
  let appointment = {
   customerId: structuredClone(newAppointment.customerId),
   stylistId: structuredClone(newAppointment.stylistId),
   appointmentTime: `${appointmentDate}T${appointmentTime}:00`,
   services: structuredClone(newAppointment.selectedServices),
  };
  postAppointment(appointment)
   .then(toggle())
   .then(() => getData());
 };

 return (
  <div>
   <Button color="primary" onClick={toggle}>
    Create Appointment
   </Button>
   <Modal isOpen={modal} toggle={toggle}>
    <ModalHeader toggle={toggle}>Create New Appointment</ModalHeader>
    <ModalBody>
     <Input
      type="Date"
      onChange={(e) => {
       setAppointmentDate(e.target.value);
      }}
     ></Input>
     <Input
      type="Time"
      onChange={(e) => {
       setAppointmentTime(e.target.value);
      }}
     ></Input>
     <Label for="stylistSelect">Stylist:</Label>
     <Input
      id="stylistSelect"
      name="select"
      type="select"
      onChange={(e) => {
       const selectedStylist = stylists.find((s) => s.name === e.target.value);
       setNewAppointment({ ...newAppointment, stylistId: selectedStylist.id });
      }}
     >
      {stylists.map((stylist) => {
       return <option>{stylist.name}</option>;
      })}
     </Input>
     <Label for="customerSelect">Customer:</Label>
     <Input
      id="customerSelect"
      name="select"
      type="select"
      onChange={(e) => {
       const selectedCustomer = customers.find(
        (c) => c.name === e.target.value
       );
       setNewAppointment({
        ...newAppointment,
        customerId: selectedCustomer.id,
       });
      }}
     >
      {customers.map((customer) => {
       return <option>{customer.name}</option>;
      })}
     </Input>
     <CardText>Services</CardText>
     <div>
      {services.map((service) => {
       return (
        <div key={service.id}>
         <input
          type="checkbox"
          id={`service-${service.id}`}
          onChange={(e) => {
           handleCheckboxCheck(e, service);
          }}
         />
         <label>{service?.name}</label>
        </div>
       );
      })}
     </div>
    </ModalBody>
    <ModalFooter>
     <Button color="primary" onClick={handleSubmit}>
      Submit Appointment
     </Button>{" "}
     <Button color="secondary" onClick={toggle}>
      Cancel
     </Button>
    </ModalFooter>
   </Modal>
  </div>
 );
}

export default AppointmentCreateModal;
