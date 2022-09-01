import { makeAutoObservable, runInAction } from "mobx";
import { store } from "./store";
import agent from "../api/agent";


export default class UserStore {
    user = null;

    constructor() {
        makeAutoObservable(this);
    }

    login = async (creds) => {
        try {
            const user = await agent.Account.login(creds);
            store.commonStore.setToken(user.token);
            runInAction(() => (this.user = user));
        } catch (error) {
            throw error;
        }
    };
}