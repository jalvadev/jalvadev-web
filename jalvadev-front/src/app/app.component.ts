import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { MessagesComponent } from './components/messages/messages.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavbarComponent, MessagesComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.less'
})
export class AppComponent {
  title = 'jalvadev-front';
}
