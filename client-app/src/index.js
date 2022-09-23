import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import NavBar from "./components/NavBar/NavBar";
import WorkItemList from "./components/WorkItem/WorkItemList"
import WorkItemTypeList from "./components/WorkItemType/WorkItemTypeList";
import reportWebVitals from "./reportWebVitals";
import { Auth0Provider, withAuthenticationRequired } from "@auth0/auth0-react";
import {
  BrowserRouter,
  Route,
  Routes,
  useNavigate
} from "react-router-dom";

const ProtectedRoute = ({ component, ...args }) => {
  const Component = withAuthenticationRequired(component, args);
  return <Component />;
};

const Auth0ProviderWithRedirectCallback = ({ children, ...props }) => {
  const navigate = useNavigate();
  const onRedirectCallback = (appState) => {
    navigate((appState && appState.returnTo) || window.location.pathname);
  };
  return (
    <Auth0Provider onRedirectCallback={onRedirectCallback} {...props}>
      {children}
    </Auth0Provider>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <Auth0ProviderWithRedirectCallback
      domain="millner.auth0.com"
      clientId="k4pavHGKY71S2MibLXJGsQGiTJ6MFtlO"
      redirectUri={window.location.origin}
    >
      <React.StrictMode>
        <NavBar />
        <Routes>
          <Route path="/" element={<App />} />
          <Route path="/workItems" element={<ProtectedRoute component={WorkItemList} />} />
          <Route path="/workItemTypes" element={<ProtectedRoute component={WorkItemTypeList} />} />
        </Routes>
      </React.StrictMode>
    </Auth0ProviderWithRedirectCallback>
  </BrowserRouter>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
