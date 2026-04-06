import { createFeatureSelector, createSelector } from "@ngrx/store";
import { ProjectsState } from "./projects.reducer";

export const selectProjectsState = createFeatureSelector<ProjectsState>('projects');

export const selectProjects = createSelector(selectProjectsState, s => s.projects);
export const selectProjectsLoading = createSelector(selectProjectsState, s => s.loading);
export const selectProjectsError = createSelector(selectProjectsState, s => s.error);
export const selectProjectsLoaded = createSelector(selectProjectsState, s => s.loaded);