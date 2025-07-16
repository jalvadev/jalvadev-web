import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { PostComponent } from './pages/post/post.component';
import { BlogComponent } from './pages/blog/blog.component';

export const routes: Routes = [
    {
        component: HomeComponent,
        path: ''
    },
    {
        component: BlogComponent,
        path: 'posts'
    },
    {
        component: PostComponent,
        path: 'posts/:id'
    }
];
