import { createContext, useContext } from "react"
import UserStore from "./userStore";
import CommonStore from "./commonStore"
import WeatherStore from "./weatherStore";


export const store = {
    userStore: new UserStore(),
    commonStore: new CommonStore(),
    weatherStore: new WeatherStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext)
}