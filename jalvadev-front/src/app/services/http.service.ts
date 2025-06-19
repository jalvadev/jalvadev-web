import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private translate: TranslateService) { }

  async get(url: string): Promise<any> {
    try{
      debugger;
      const response = await fetch(url);
      if(!response.ok)
        return new Promise<any>((resolve, reject) => { resolve({ error: this.translate.instant("HTTP_KO") }) });

      const data = await response.json();
      return data;
    }catch(error: any){
      console.log(error.message);
      return new Promise<any>((resolve, reject) => {
        resolve({
          error: this.translate.instant("HTTP_PROCESS_ERROR"),
          internalError: error.message
        })
      });
    }
  }
}
