import { inject, Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { firstValueFrom, Observable } from 'rxjs';
import { MessagesService } from './messages.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Project } from '../interfaces/project';
import { ApiResponse } from '../interfaces/api.response';
import { environment } from '../../environment.pro';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  apiURL = environment.apiUrl;
  options: { headers: HttpHeaders };
  httpClient = inject(HttpClient);
  messageService = inject(MessagesService);
  translate = inject(TranslateService);

  constructor(){
    this.options = {
      headers: new HttpHeaders()
    };
  }

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

  getProjects(userId: number): Observable<ApiResponse<Project[]>>{
    return this.httpClient.get<ApiResponse<Project[]>>(`${this.apiURL}Project/user/${userId}`, this.options)
  }
}
