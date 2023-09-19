import { useEffect, useState } from "react";
import { getCustomers } from "../../Data/customerData";
import { Link } from "react-router-dom";
import { Button, Spinner, Table } from "reactstrap";
import CustomerFormModal from "./CustomerFormModal";

export const CustomerView = () => {
 const [customers, setCustomers] = useState([]);
 async function getData() {
  getCustomers().then(setCustomers);
 }

 useEffect(() => {
  getData();
 }, []);

 if (customers.length === 0) {
  return <Spinner />;
 }

 return (
  <div className="container">
   <h4>Customers</h4>
   <Table>
    <thead>
     <tr>
      <th>Id</th>
      <th>Customer Name</th>
     </tr>
    </thead>
    <tbody>
     {customers.map((c) => {
      return (
       <tr>
        <td>{c.id}</td>
        <td>{c.name}</td>
        <td></td>
       </tr>
      );
     })}
    </tbody>
   </Table>
   <CustomerFormModal getData={getData} />
  </div>
 );
};
