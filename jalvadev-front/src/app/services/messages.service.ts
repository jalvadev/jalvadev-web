import { EventEmitter, inject, Injectable, Output } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessagesService {

  @Output() eventMessage: EventEmitter<string> = new EventEmitter();

  constructor() { }


  showMessage(message: string){
    this.eventMessage.emit(message);
  }
}
