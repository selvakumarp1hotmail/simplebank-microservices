import React, { useEffect, useState } from "react";
import { getCustomers, getAccounts, getTransactions, createTransaction } from "./api";
import "./App.css";

function App() {
  const [customers, setCustomers] = useState([]);
  const [accounts, setAccounts] = useState([]);
  const [transactions, setTransactions] = useState([]);

  const [amount, setAmount] = useState("");
  const [type, setType] = useState("Deposit");

  const handleTransaction = async () => {
    if (!amount || isNaN(amount)) return;

    await createTransaction({
      accountId: accounts[0]?.id,
      amount: parseFloat(amount),
      type: type
    });

    const updatedAccounts = await getAccounts();
    const updatedTransactions = await getTransactions();

    setAccounts(updatedAccounts);
    setTransactions(updatedTransactions);
    setAmount("");
  };

  useEffect(() => {
    getCustomers().then(setCustomers);
    getAccounts().then(setAccounts);
    getTransactions().then(setTransactions);
  }, []);

  return (
    <div className="container">
      <h1>🏦 SELVA's -Simple Bank Dashboard</h1>

      {/* ✅ TRANSACTION FORM */}
      <div className="card">
        <h2>💰 Transaction: Deposit/WithDraw</h2>

        <input
          type="number"
          placeholder="Amount"
          value={amount}
          onChange={(e) => setAmount(e.target.value)}
        />

        <select value={type} onChange={(e) => setType(e.target.value)}>
          <option value="Deposit">Deposit</option>
          <option value="Withdraw">Withdraw</option>
        </select>

        <button onClick={handleTransaction}>Submit</button>
      </div>

      {/* ✅ ACCOUNTS */}
      <div className="card">
        <h2>💳 Accounts</h2>

        <table>
          <thead>
            <tr>
              <th>Account</th>
              <th>Balance</th>
              <th>Currency</th>
            </tr>
          </thead>

          <tbody>
            {accounts.map((a) => (
              <tr key={a.id}>
                <td>{a.accountNumber}</td>
                <td className="balance">${a.balance}</td>
                <td>{a.currency}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* ✅ CUSTOMERS */}
      <div className="card">
        <h2>👤 Customers</h2>

        <table>
          <thead>
            <tr>
              <th>Name</th>
              <th>Email</th>
              <th>Phone</th>
              <th>KYC</th>
            </tr>
          </thead>

          <tbody>
            {customers.map((c) => (
              <tr key={c.id}>
                <td>{c.fullName}</td>
                <td>{c.email}</td>
                <td>{c.phone}</td>
                <td>{c.kycStatus}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {/* ✅ TRANSACTIONS */}
      <div className="card">
        <h2>📊 Transactions</h2>

        <table>
          <thead>
            <tr>
              <th>Type</th>
              <th>Amount</th>
              <th>Date</th>
            </tr>
          </thead>

          <tbody>
            {transactions.map((t) => (
              <tr key={t.id}>
                <td>{t.type}</td>
                <td>${t.amount}</td>
                <td>{new Date(t.createdAt).toLocaleString()}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default App;