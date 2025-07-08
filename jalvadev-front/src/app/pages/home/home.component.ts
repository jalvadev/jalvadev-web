import { Component, inject } from '@angular/core';
import { MessagesService } from '../../services/messages.service';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.less'
})
export class HomeComponent {

  constructor(){
    const service = inject(MessagesService);
    service.showMessage("Desde el app component!");
  }

}
