import { Component, ElementRef, inject, Input, Renderer2 } from '@angular/core';
import { MessagesService } from '../../services/messages.service';
@Component({
  selector: 'app-messages',
  imports: [],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.less'
})
export class MessagesComponent{

  @Input() message!: string;

  MILLISECONDS_TO_DISPLAY: number = 5000;

  messagesService = inject(MessagesService);
  elementRef = inject(ElementRef);
  renderer = inject(Renderer2);

  constructor(){
    this.messagesService.eventMessage.subscribe((message: string) => { debugger; this.showMessage(message); });
  }

  showMessage(message: string){
    debugger;
    this.message = message;

    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    
    this.renderer.addClass(container, "fade-in");
    this.hideMessage();
  }

  hideMessage(){
    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    
    setTimeout(() => {
        this.renderer.addClass(container, "fade-out");
        this.renderer.removeClass(container, "fade-in");
    }, this.MILLISECONDS_TO_DISPLAY);
  }
}
