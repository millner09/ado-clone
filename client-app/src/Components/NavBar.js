// src/App.js
import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { Link } from "react-router-dom";

function NavBar() {
    const { isAuthenticated, loginWithRedirect, logout } =
        useAuth0();
    if (isAuthenticated) {
        return (
            <div>
                <Link to="/">
                    <h1>ADO Clone</h1>
                </Link>                <button onClick={() => logout({ returnTo: window.location.origin })}>
                    Log out
                </button>
            </div>
        );
    } else {
        return (
            <>
                <Link to="/">
                    <h1>ADO Clone</h1>
                </Link>
                <button onClick={loginWithRedirect}>Log in</button>
            </>
        )
    }
}

export default NavBar;
