import { AppointmentCard } from "../Components/AppointmentView/AppointmentCard";

const _apiUrl = "/api/appointments";

export const getAppointments = () => {
 return fetch(_apiUrl).then((res) => res.json());
};

export const updateService = (id, appointment) => {
 return fetch(`/api/appointmentservices/${id}`, {
  method: "PUT",
  headers: {
   "Content-Type": "application/json",
  },
  body: JSON.stringify(appointment),
 });
};

export const postAppointment = (appointment) => {
 return fetch(_apiUrl, {
  method: "POST",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify(appointment),
 });
};

export const deleteAppointment = (id) => {
 return fetch(`${_apiUrl}/${id}`, {
  method: "DELETE",
 });
};
