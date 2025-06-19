import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async get(url: string): Promise<any> {
    try{
      const response = await fetch(url);
      if(!response.ok)
        return new Promise<any>((resolve, reject) => { resolve({ error: "Error processing the call." }) });

      const data = await response.json();
      return data;
    }catch(error: any){
      console.log(error.message);
      return new Promise<any>((resolve, reject) => {
        resolve({
          error: "An error ocurred when attemp to make an http call.",
          internalError: error.message
        })
      });
    }
  }
}
