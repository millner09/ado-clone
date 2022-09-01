import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";
import { useEffect } from "react";


function App() {
  const { commonStore, userStore, weatherStore } = useStore();

  const getWeather = async () => {
    const res = await weatherStore.weather();
    console.log(res);
  }

  const getWeatherAuth = async () => {
    const res = await weatherStore.weatherAuth();
    console.log(res);
  }

  const getToken = async () => {
    var creds = {
      "email": "adam.millner@gmail.com",
      "password": "Pa$$w0rd"
    }
    await userStore.login(creds);
  }


  useEffect(() => {
    getToken();
    getWeather();
    getWeatherAuth();
  }, [commonStore, weatherStore])
  return (
    <div>
      <h1>ADO Clone</h1>
    </div>
  );
}

export default observer(App);
