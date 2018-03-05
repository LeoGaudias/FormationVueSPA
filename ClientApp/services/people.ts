import Axios, { AxiosRequestConfig } from "axios";
import { IPersonViewModel } from "../viewmodels/person";
import { IPersonFormViewModel } from "../viewmodels/personForm";

export default class PeopleService {
  private static _instance: PeopleService;

  private readonly _backendUrlDotNet: string = "/api/People";

  // private readonly options : AxiosRequestConfig = {
  //   headers: {
  //     "Content-Type": "application/x-www-form-urlencoded; charset=utf-8",
  //     "Access-Control-Allow-Origin": "*",
  //     "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE"
  //   }
  // };

  private constructor() { }

  static createInstance(): void {
    PeopleService.getInstance();
  }

  static getInstance(): PeopleService {
    return this._instance || (this._instance = new this());
  }

  public getAll(): Promise<IPersonViewModel[]> {
    return Axios.get(`${this._backendUrlDotNet}/getAll`).then(result => result.data);
  }

  public getById(id: number): Promise<IPersonViewModel> {
    return Axios.get(`${this._backendUrlDotNet}/getById?personId=${id}`).then(response => response.data);
  }

  public getRandom(): Promise<IPersonViewModel> {

    return Axios.get(`${this._backendUrlDotNet}/getRandom`).then(result => result.data);
  }

  public delete(id: number): Promise<any> {
    return Axios.delete(`${this._backendUrlDotNet}/delete?personId=${id}`).then(response => response.data);
  }

  public create(vm: IPersonFormViewModel): Promise<any> {
    return Axios.post(`${this._backendUrlDotNet}/create`, vm).then(response => response.data);
  }

  public update(vm: IPersonFormViewModel): Promise<any> {
    return Axios.put(`${this._backendUrlDotNet}/update`, vm).then(response => response.data);
  }
}