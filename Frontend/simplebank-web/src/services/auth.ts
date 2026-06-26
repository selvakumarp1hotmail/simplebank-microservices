import axios from "axios";

export const login = async () => {
  const res = await axios.post("http://a1c9a2c0563cf40098cf94958de56fb8-1348290131.ap-southeast-1.elb.amazonaws.com/api/auth/login");
  //const res = await axios.post("http://localhost:5103/api/auth/login");//used before Kubernetes, docker
  return res.data.token;
};