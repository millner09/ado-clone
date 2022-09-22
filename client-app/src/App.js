// src/App.js
import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Link } from "react-router-dom";

function App() {
  const { isLoading, isAuthenticated, error } =
    useAuth0();

  if (isLoading) {
    return <div>Loading...</div>;
  }
  if (error) {
    return <div>Oops... {error.message}</div>;
  }

  if (isAuthenticated) {
    return (
      <div>
        <div>
          <Link to={"workItems"}>
            Work Items
          </Link>
        </div>
        <div>
          <Link to={"workItemTypes"}>
            Work Item Types
          </Link>
        </div>
      </div>
    );
  }
}

export default App;
