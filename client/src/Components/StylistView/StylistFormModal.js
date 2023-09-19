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
} from "reactstrap";

import { postStylist } from "../../Data/stylistData";

function StylistFormModal({ getData }) {
 const [modal, setModal] = useState(false);
 const [stylistToPost, setStylistToPost] = useState({
  name: "",
  isActive: true,
 });
 const toggle = () => setModal(!modal);

 async function handleSubmit() {
  postStylist(stylistToPost).then(getData).then(toggle);
 }

 return (
  <div>
   <Button color="primary" onClick={toggle}>
    Hire New Stylist
   </Button>
   <Modal isOpen={modal} toggle={toggle}>
    <ModalHeader toggle={toggle}>Enter Stylist Information!</ModalHeader>
    <ModalBody>
     <InputGroup size="m">
      <InputGroupText>Stylist Name</InputGroupText>
      <Input
       onChange={(event) =>
        setStylistToPost({ ...stylistToPost, name: event.target.value })
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

export default StylistFormModal;
