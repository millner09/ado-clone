// src/App.js
import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import WeatherList from "./Components/WeatherList";

function App() {
  const { isLoading, isAuthenticated, error, user, loginWithRedirect, logout } =
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
        Hello {user.name}{" "}
        <button onClick={() => logout({ returnTo: window.location.origin })}>
          Log out
        </button>
        <WeatherList />
      </div>
    );
  } else {
    return <button onClick={loginWithRedirect}>Log in</button>;
  }
}

export default App;
