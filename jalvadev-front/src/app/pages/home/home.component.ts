import { Component } from '@angular/core';
import { MessagesComponent } from "../../components/messages/messages.component";

@Component({
  selector: 'app-home',
  imports: [MessagesComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.less'
})
export class HomeComponent {

}
