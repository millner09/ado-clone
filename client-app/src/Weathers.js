import React, { useEffect, useState } from "react";
import { useAuth0 } from "@auth0/auth0-react";

const Weathers = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [weathers, setWeathers] = useState(null);

  useEffect(() => {
    (async () => {
      try {
        const token = await getAccessTokenSilently({
          audience: "https://amillner-ado-clone/",
        });
        const response = await fetch(
          "http://localhost:5167/api/weatherforecast",
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        );

        var body = await response.json();
        setWeathers(body);
        console.log(body);
      } catch (e) {
        console.error(e);
      }
    })();
  }, [getAccessTokenSilently]);

  if (!weathers) {
    return <div>Loading...</div>;
  }

  return (
    <ul>
      {weathers.map((weather, index) => {
        return (
          <li key={index}>
            {weather.date} - {weather.temperatureF}
          </li>
        );
      })}
    </ul>
  );
};

export default Weathers;
