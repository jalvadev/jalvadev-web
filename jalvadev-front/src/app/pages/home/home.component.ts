import { Component, inject } from '@angular/core';
import { MessagesService } from '../../services/messages.service';
import { Project } from '../../interfaces/project';
import { HttpService } from '../../services/http.service';
import { ApiResponse } from '../../interfaces/api.response';
import { CardListComponent } from "../../components/card-list/card-list.component";
@Component({
  selector: 'app-home',
  imports: [CardListComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.less'
})
export class HomeComponent {

  httpService: HttpService = inject(HttpService);
  messageService: MessagesService = inject(MessagesService);

  projects!: Project[];


  constructor(){
    this.loadProjects();
  }

  loadProjects(){
    this.httpService.getProjects(1).subscribe({
      next: (res: ApiResponse<Project[]>) => {
        if(res && res.isSuccess){
          var value = res.value;
          this.projects = value;
        }else{ this.messageService.showMessage(res.message); }
      },
      error: (error: any) => { this.messageService.showError(error); }
    })
  }
}
