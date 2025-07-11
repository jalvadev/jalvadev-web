import { EventEmitter, inject, Injectable, Output } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { firstValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {

  @Output() eventMessage: EventEmitter<string> = new EventEmitter();

  translate = inject(TranslateService);
  
  constructor() { }


  showMessage(message: string){
    this.eventMessage.emit(message);
  }

  async showError(error: any){
    if(error && error.message)
      this.eventMessage.emit(error.message);
    else
    {
      const message = await firstValueFrom(this.translate.get("BASE_ERRORS.HTTP_KO"));
      this.eventMessage.emit(message);
    }
  }
}
