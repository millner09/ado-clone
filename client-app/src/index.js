import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import WorkItemList from "./components/WorkItemList"
import reportWebVitals from "./reportWebVitals";
import { Auth0Provider } from "@auth0/auth0-react";
import {
  BrowserRouter,
  Route,
  Routes,
} from "react-router-dom";
import NavBar from "./components/NavBar";
import WorkItemTypeList from "./components/WorkItemTypeList";


const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <Auth0Provider
    domain="millner.auth0.com"
    clientId="k4pavHGKY71S2MibLXJGsQGiTJ6MFtlO"
    redirectUri={window.location.origin}
  >
    <React.StrictMode>
      <BrowserRouter>
        <NavBar />
        <Routes>
          <Route path="/" element={<App />} />
          <Route path="/workItems" element={<WorkItemList />} />
          <Route path="/workItemTypes" element={<WorkItemTypeList />} />
        </Routes>
      </BrowserRouter>
    </React.StrictMode>
  </Auth0Provider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
