import { inject, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  translate = inject(TranslateService);

  async get(url: string): Promise<any> {
    try{
      debugger;
      const response = await fetch(url);
      if(!response.ok)
        return new Promise<any>(async (resolve, reject) => { 
          const msg = await firstValueFrom(this.translate.get("BASE_ERRORS.HTTP_KO"));
          resolve({ error: msg}) 
        });

      const data = await response.json();
      return data;
    }catch(error: any){
      console.log(error.message);
      return new Promise<any>(async (resolve, reject) => {
        const msg = await firstValueFrom(this.translate.get("BASE_ERRORS.HTTP_PROCESS_ERROR"));

        resolve({
          error: msg,
          internalError: error.message
        })
      });
    }
  }
}
