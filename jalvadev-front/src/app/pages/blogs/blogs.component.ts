import { Component, inject, OnInit } from '@angular/core';
import { HttpService } from '../../services/http.service';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-blogs',
  imports: [TranslateModule],
  templateUrl: './blogs.component.html',
  styleUrl: './blogs.component.less'
})
export class BlogsComponent implements OnInit{

  http: HttpService = inject(HttpService);

  ngOnInit(): void {
    this.http.get("http://localhost:8080/api/User");
  }
}
