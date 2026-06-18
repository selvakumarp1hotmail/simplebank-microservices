import axios from "axios";

export const login = async () => {
  const res = await axios.post("http://localhost:5103/api/auth/login");
  return res.data.token;
};