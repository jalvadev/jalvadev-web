import { inject, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { firstValueFrom } from 'rxjs';
import { MessagesService } from './messages.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  messageService = inject(MessagesService);
  translate = inject(TranslateService);

  async get(url: string): Promise<any> {
    try{
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
      this.messageService.showMessage(error.message);

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
