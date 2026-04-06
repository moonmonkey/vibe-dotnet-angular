import { Component, ChangeDetectionStrategy, inject } from '@angular/core';
import { AsyncPipe } from "@angular/common";
import { Store } from "@ngrx/store";
import { MatButtonModule } from "@angular/material/button";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatCardModule } from "@angular/material/card";
import { MatIconModule } from "@angular/material/icon";
import { loadProjects } from "../../../store/projects/projects.actions";
import {
    selectProjects,
    selectProjectsLoading,
    selectProjectsError,
    selectProjectsLoaded
} from "../../../store/projects/projects.selectors";
import { ProjectListComponent } from "../project-list/project-list.component"; 

@Component({
    selector: "app-projects-page",
    standalone: true,
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [
        AsyncPipe,
        MatButtonModule,
        MatProgressSpinnerModule,
        MatCardModule,
        MatIconModule,
        ProjectListComponent
    ],
    templateUrl: "./projects-page.component.html",
    styleUrls: ["./projects-page.component.scss"]
})
export class ProjectsPageComponent {
  private store = inject(Store);

  projects$ = this.store.select(selectProjects);
  loading$ = this.store.select(selectProjectsLoading);
  error$ = this.store.select(selectProjectsError);
  loaded$ = this.store.select(selectProjectsLoaded);

  onLoadProjects(): void {
    this.store.dispatch(loadProjects());
  }
}