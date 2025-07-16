import { Component, Input } from '@angular/core';
import { TranslateModule } from '@ngx-translate/core';

@Component({
  selector: 'app-blog',
  imports: [TranslateModule],
  templateUrl: './blog.component.html',
  styleUrl: './blog.component.less'
})
export class BlogComponent {
  @Input() id!: number;
  
}
