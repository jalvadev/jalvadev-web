import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { BlogsComponent } from './pages/blogs/blogs.component';
import { BlogDetailComponent } from './pages/blog-detail/blog-detail.component';

export const routes: Routes = [
    {
        component: HomeComponent,
        path: ''
    },
    {
        component: BlogsComponent,
        path: 'posts'
    },
    {
        component: BlogDetailComponent,
        path: 'posts/:id'
    }
];
