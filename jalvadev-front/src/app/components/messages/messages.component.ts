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
    this.messagesService.eventMessage.subscribe((message: string) => { this.showMessage(message); });
  }

  showMessage(message: string){
    this.message = message;

    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    
    this.renderer.removeClass(container, "fade-out");
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
