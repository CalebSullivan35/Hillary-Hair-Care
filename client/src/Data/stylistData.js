const _apiUrl = "/api/stylists";

export const getStylists = () => {
 return fetch(_apiUrl).then((res) => res.json());
};

//deactivate user.
export const deactivateStylist = async (id) => {
 const response = await fetch(`${_apiUrl}/${id}/deactivate`, {
  method: "PUT",
  headers: {
   "Content-Type": "application/json",
  },
 });
 if (!response.ok) {
  console.log("Failed to Deactivate Stylist");
 }
 console.log("Stylist Succesfully Deactivated!");
 return response.json();
};

//activate user.
export const activateStylist = async (id) => {
 const response = await fetch(`${_apiUrl}/${id}/activate`, {
  method: "PUT",
  headers: {
   "Content-Type": "application/json",
  },
 });
 if (!response.ok) {
  console.log("Failed to Deactivate Stylist");
 }
 console.log("Stylist Succesfully Deactivated!");
 return response.json();
};

//post a new stylist
export const postStylist = (stylist) => {
 return fetch(_apiUrl, {
  method: "POST",
  headers: { "Content-Type": "application/json" },
  body: JSON.stringify(stylist),
 }).then((res) => res.json());
};
