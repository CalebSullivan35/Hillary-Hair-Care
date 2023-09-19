import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import "bootstrap/dist/css/bootstrap.min.css";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { CustomerView } from "./Components/CustomerView/CustomerView";
import { StylistView } from "./Components/StylistView/StylistView";
import { AppointmentView } from "./Components/AppointmentView/AppointmentView";
import { AppointmentCreate } from "./Components/AppointmentView/AppointmentCreateModal";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
 <BrowserRouter>
  <Routes>
   <Route path="/" element={<App />}>
    <Route index element={<AppointmentView />} />
    <Route path="customers" element={<CustomerView />} />
    <Route path="Stylists" element={<StylistView />} />
   </Route>
  </Routes>
 </BrowserRouter>
);

reportWebVitals();
