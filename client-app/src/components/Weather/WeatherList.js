import React, { useEffect, useState } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import Weather from "./Weather";

const WeatherList = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [weathers, setWeathers] = useState(null);

  useEffect(() => {
    (async () => {
      try {
        const token = await getAccessTokenSilently({
          audience: "https://amillner-ado-clone/",
        });
        const response = await fetch(
          `${process.env.REACT_APP_API_URL}/weatherforecast`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        var body = await response.json();
        setWeathers(body);
      } catch (e) {
        console.error(e);
      }
    })();
  }, [getAccessTokenSilently]);

  if (!weathers) {
    return <div>Loading...</div>;
  }

  return (
    weathers.map((weather, index) => {
      return (
        <Weather key={index} weather={weather} />
      );
    })
  );
};

export default WeatherList;
