import { createReducer, on } from "@ngrx/store";
import { Project } from "../../models/project.model";
import { loadProjects, loadProjectsFailure, loadProjectsSuccess } from "./projects.actions";

export interface ProjectsState {
    projects: Project[];
    loading: boolean;
    error: string | null;
    loaded: boolean;
}

const initialState: ProjectsState = {
    projects: [],
    loading: false,
    error: null,
    loaded: false
};

export const projectsReducer = createReducer(
    initialState,
    on(loadProjects, state => ({...state, loading: true, error: null })),
    on(loadProjectsSuccess, (state, { projects }) => ({...state, projects, loading: false, loaded: true })),
    on(loadProjectsFailure, (state, { error }) => ({...state, error, loading: false, loaded: true }))

);