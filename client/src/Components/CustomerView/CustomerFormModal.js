import React, { useState } from "react";
import {
 Button,
 Modal,
 ModalHeader,
 ModalBody,
 ModalFooter,
 InputGroup,
 Input,
 InputGroupText,
 Spinner,
} from "reactstrap";
import { postCustomer } from "../../Data/customerData";

function CustomerFormModal({ getData }) {
 const [modal, setModal] = useState(false);
 const [customerToPost, setCustomerToPost] = useState({ name: "" });
 const toggle = () => setModal(!modal);

 async function handleSubmit(e) {
  e.preventDefault();
  postCustomer(customerToPost).then(getData).then(toggle);
 }

 return (
  <div>
   <Button color="primary" onClick={toggle}>
    Add New Customer
   </Button>
   <Modal isOpen={modal} toggle={toggle}>
    <ModalHeader toggle={toggle}>Enter Customer Information!</ModalHeader>
    <ModalBody>
     <InputGroup size="m">
      <InputGroupText>Customer Name</InputGroupText>
      <Input
       onChange={(event) =>
        setCustomerToPost({ ...customerToPost, name: event.target.value })
       }
      />
     </InputGroup>
    </ModalBody>
    <ModalFooter>
     <Button color="primary" onClick={() => handleSubmit()}>
      Submit
     </Button>{" "}
     <Button color="danger" onClick={toggle}>
      Cancel
     </Button>
    </ModalFooter>
   </Modal>
  </div>
 );
}

export default CustomerFormModal;
