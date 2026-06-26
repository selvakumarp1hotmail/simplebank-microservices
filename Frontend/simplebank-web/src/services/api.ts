import axios from "axios";

export const api = axios.create({
  //baseURL: "http://localhost:5103/api/gateway"//used before Kubenetes, Docker.
  baseURL: "http://a1c9a2c0563cf40098cf94958de56fb8-1348290131.ap-southeast-1.elb.amazonaws.com/api/gateway/api/gateway"
});

// ✅ AUTO ATTACH TOKEN
api.interceptors.request.use(config => {
  const token = localStorage.getItem("token");

  if (token) {
    config.headers.Authorization = `Bearer ${token}`;
  }

  return config;
});