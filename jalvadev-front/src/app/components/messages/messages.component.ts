import { Component, ElementRef, inject, Input, OnInit, Renderer2 } from '@angular/core';
@Component({
  selector: 'app-messages',
  imports: [],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.less'
})
export class MessagesComponent implements OnInit {

  @Input() message!: string;

  MILLISECONDS_TO_DISPLAY: number = 5000;

  elementRef = inject(ElementRef);
  renderer = inject(Renderer2);

  constructor(){}


  ngOnInit(): void {
    this.showMessage();
  }

  showMessage(){
    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    
    this.renderer.addClass(container, "fade-in");
    this.hideMessage();
  }

  hideMessage(){
    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    
    setTimeout(() => {
        this.renderer.removeClass(container, "fade-in");
    }, this.MILLISECONDS_TO_DISPLAY);
  }
}
