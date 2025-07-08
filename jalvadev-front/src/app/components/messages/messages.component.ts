import { Component, ElementRef, inject, Input, OnInit, Renderer2 } from '@angular/core';
import { timeout } from 'rxjs';

@Component({
  selector: 'app-messages',
  imports: [],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.less'
})
export class MessagesComponent implements OnInit {

  @Input() message!: string;

  MILLISECONDS_TO_DISPLAY: number = 3000;

  elementRef = inject(ElementRef);
  renderer = inject(Renderer2);

  constructor(){}


  ngOnInit(): void {
    this.showMessage();
  }

  showMessage(){
    var container = this.elementRef.nativeElement.querySelector('div.message-container');
    this.renderer.setStyle(container, "display", "block");

    setTimeout(() => {
        this.renderer.setStyle(container, "display", "none");
    }, this.MILLISECONDS_TO_DISPLAY);

    debugger;
  }
}
