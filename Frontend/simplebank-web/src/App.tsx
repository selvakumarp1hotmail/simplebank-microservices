import { useEffect, useState } from "react";
import { api } from "./services/api";
import type { Customer } from "./models/customer";
import { login } from "./services/auth";

function App() {
  const [customers, setCustomers] = useState<Customer[]>([]);

  // ✅ STEP 1 — LOGIN + STORE TOKEN
  useEffect(() => {
    login().then(token => {
      console.log("TOKEN:", token);
      localStorage.setItem("token", token);
    });
  }, []);

  // ✅ STEP 2 — CALL API USING TOKEN
  useEffect(() => {
    api.get("/customers")
      .then(res => {
        console.log("API RESPONSE:", res.data);
        setCustomers(res.data);
      })
      .catch(err => console.error(err));
  }, []);

  return (
    <div>
      <h1>Customers</h1>

      <ul>
        {customers.map((c) => (
          <li key={c.id}>
            {c.fullName} - {c.email}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;
