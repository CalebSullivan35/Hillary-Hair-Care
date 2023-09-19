import { useEffect, useState } from "react";
import { AppointmentCard } from "./AppointmentCard";
import { getAppointments } from "../../Data/appointmentData";
import { getServices } from "../../Data/servicesData";
import { Button } from "reactstrap";
import AppointmentCreateModal from "./AppointmentCreateModal";
import { getStylists } from "../../Data/stylistData";
import { getCustomers } from "../../Data/customerData";

export const AppointmentView = () => {
 const [appointments, setAppointments] = useState([]);
 const [services, setServices] = useState([]);
 const [stylists, setStylists] = useState([]);
 const [customers, setCustomers] = useState([]);

 async function customerData() {
  getCustomers().then(setCustomers);
 }

 async function getActiveStylists() {
  const unfilteredstylists = await getStylists();
  const filteredStylists = unfilteredstylists.filter(
   (s) => s.isActive === true
  );
  setStylists(filteredStylists);
 }
 async function getData() {
  getAppointments().then(setAppointments);
 }

 async function fetchServices() {
  getServices().then(setServices);
 }
 useEffect(() => {
  fetchServices();
  getData();
  getActiveStylists();
  customerData();
 }, []);
 if (appointments.length == 0 || services.length == 0) {
  return "";
 }
 return (
  <>
   <div id="createAppointmentContainer">
    <AppointmentCreateModal
     stylists={stylists}
     services={services}
     customers={customers}
     getData={getData}
    />
   </div>
   <div className="appointmentContainer">
    {appointments.map((appointment) => {
     return (
      <AppointmentCard
       appointment={appointment}
       services={services}
       getData={getData}
      />
     );
    })}
   </div>
  </>
 );
};
