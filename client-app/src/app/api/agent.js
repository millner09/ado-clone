import axios, { AxiosError, AxiosResponse } from "axios";
import { store } from "../stores/store";

const sleep = (delay) => {
    return new Promise((resolve) => {
        setTimeout(resolve, delay);
    });
};

axios.defaults.baseURL = "http://localhost:5167/api";

axios.interceptors.request.use((config) => {
    const token = store.commonStore.token;
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
});


const responseBody = (response) => response.data;

axios.interceptors.response.use(
    async (response) => {
        await sleep(1000);
        return response;
    }
)

const requests = {
    get: (url) => axios.get(url).then(responseBody),
    post: (url, body) =>
        axios.post(url, body).then(responseBody),
    put: (url, body) => axios.put(url, body).then(responseBody),
    del: (url) => axios.delete(url).then(responseBody),
};

const Account = {
    current: () => requests.get("/account"),
    login: (user) => requests.post("/account/login", user),
    register: (user) =>
        requests.post("/account/register", user),
};

const Weather = {
    getWeather: () => requests.get("/weatherforecast"),
    getWeatherAuth: () => requests.post("/weatherforecast")
}

const agent = {
    Account,
    Weather
};

export default agent;