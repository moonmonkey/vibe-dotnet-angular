import { Routes } from '@angular/router';
import { ProjectsPageComponent } from './components/projects/projects-page/projects-page.component';

export const routes: Routes = [
    { path: '', redirectTo: 'projects', pathMatch: 'full' },
    { path: 'projects', component: ProjectsPageComponent }
]