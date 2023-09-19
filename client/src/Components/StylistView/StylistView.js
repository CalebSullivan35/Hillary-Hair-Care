import { useEffect, useState } from "react";
import { getCustomers } from "../../Data/customerData";
import { Link } from "react-router-dom";
import { Button, Table } from "reactstrap";
import {
 activateStylist,
 deactivateStylist,
 getStylists,
} from "../../Data/stylistData";
import StylistFormModal from "./StylistFormModal";
export const StylistView = () => {
 const [stylists, setStylists] = useState([]);
 async function getData() {
  getStylists().then(setStylists);
 }

 function handleDeactivate(id) {
  deactivateStylist(id).then(() => {
   getData();
  });
 }
 function handleActivate(id) {
  activateStylist(id).then(() => {
   getData();
  });
 }

 useEffect(() => {
  getData();
 }, []);

 return (
  <div className="container">
   <h4>Stylists!</h4>
   <Table>
    <thead>
     <tr>
      <th>Id</th>
      <th>Stylist Name</th>
      <th>Status</th>
      <th>change status</th>
     </tr>
    </thead>
    <tbody>
     {stylists.map((s) => {
      return (
       <tr>
        <td>{s.id}</td>
        <td>{s.name}</td>
        <td>{s.isActive == true ? "Active" : "Inactive"}</td>
        <td>
         {s.isActive == true ? (
          <Button
           onClick={() => {
            handleDeactivate(s.id);
           }}
          >
           Deactivate
          </Button>
         ) : (
          <Button
           onClick={() => {
            handleActivate(s.id);
           }}
          >
           Activate
          </Button>
         )}
        </td>
       </tr>
      );
     })}
    </tbody>
   </Table>
   <StylistFormModal getData={getData} />
  </div>
 );
};
