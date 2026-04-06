import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, map, switchMap } from "rxjs";
import { of } from "rxjs";
import { ProjectService } from "../../services/project.service";
import { loadProjects, loadProjectsFailure, loadProjectsSuccess } from "./projects.actions";

@Injectable()
export class ProjectsEffects {
    loadProjects$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadProjects),
            switchMap(() =>
                this.projectService.getProjects().pipe(
                    map(projects => loadProjectsSuccess({ projects })),
                    catchError(error => 
                        of(loadProjectsFailure({ error: error.message })))
                )
            )
        )
    );
    constructor(
        private actions$: Actions,
        private projectService: ProjectService
    ) {}
}