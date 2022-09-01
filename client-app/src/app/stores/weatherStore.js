import { makeAutoObservable } from "mobx";
import agent from "../api/agent";


export default class WeatherStore {
    user = null;

    constructor() {
        makeAutoObservable(this);
    }

    weather = async () => {
        try {
            const weather = await agent.Weather.getWeather();
            return weather;
        } catch (error) {
            console.log(error);
        }
    }

    weatherAuth = async () => {
        try {
            const weather = await agent.Weather.getWeatherAuth();
            return weather;
        } catch (error) {
            console.log(error);
        }
    }
}