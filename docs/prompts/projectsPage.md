# Feature Prompt: Projects Page (Frontend)

Feature: Create a Projects page at `/projects` that displays all available Azure DevOps projects, loaded on demand via a button press.

## Route
- Path: `/projects`
- This is the first page of the app — redirect `/` to `/projects`

## Tasks

### 1. Model
Create `src/app/models/project.model.ts`:
- `id: string`
- `name: string`
- `description: string`
- `url: string`
- `state: string`
- `visibility: string`

### 2. API Service
Create `src/app/services/project.service.ts`:
- Typed HttpClient service
- `getProjects(): Observable<Project[]>` — calls `GET /api/pr/projects`

### 3. NgRx Store — `src/app/store/projects/`
- **Actions** (`projects.actions.ts`):
  - `loadProjects` — triggered by button press
  - `loadProjectsSuccess` — payload: `projects: Project[]`
  - `loadProjectsFailure` — payload: `error: string`
- **Reducer** (`projects.reducer.ts`):
  - State: `{ projects: Project[], loading: boolean, error: string | null, loaded: boolean }`
  - Initial state: empty, not loaded, not loading
- **Effects** (`projects.effects.ts`):
  - On `loadProjects` → call `ProjectService.getProjects()` → dispatch success or failure
- **Selectors** (`projects.selectors.ts`):
  - `selectProjects`
  - `selectProjectsLoading`
  - `selectProjectsError`
  - `selectProjectsLoaded`

### 4. Smart Container Component
Create `src/app/components/projects/projects-page/projects-page.component.ts`:
- Standalone, OnPush
- Dispatches `loadProjects` action on button press
- Selects `projects`, `loading`, `error`, `loaded` from store
- Passes data down to dumb components via inputs
- No direct API calls

### 5. Dumb Components

#### Project Card — `src/app/components/projects/project-card/project-card.component.ts`
- Standalone, OnPush
- Inputs: `project: Project`
- Displays:
  - Project name (bold, prominent)
  - Description (smaller, muted text — show "No description" if empty)
  - State badge using `mat-chip` (green for `wellFormed`, grey for all others)
  - Visibility badge using `mat-chip` (blue for `public`, orange for `private`)
  - "Open in Azure DevOps" link using `mat-button` — opens `project.url` in a new tab
- Has hover elevation effect (cursor pointer, shadow lift)
- No click action yet — visually clickable but inert

#### Project List — `src/app/components/projects/project-list/project-list.component.ts`
- Standalone, OnPush
- Input: `projects: Project[]`
- Renders a responsive grid of `project-card` components
- Uses CSS grid: 3 columns on desktop, 2 on tablet, 1 on mobile

### 6. Routing
Update app routing to:
- Add `/projects` route pointing to `ProjectsPageComponent`
- Redirect `/` to `/projects`

## UI Behaviour
- Page loads empty with no data shown
- A `mat-raised-button` labelled "Load Projects" is always visible
- On button press: dispatch `loadProjects`, show `mat-spinner`
- On success: hide spinner, show project cards grid
- On empty result: show a `mat-card` with an info icon and message "No projects found"
- On error: show a `mat-card` with an error icon and message "Failed to load projects. Please try again."
- Button remains visible after load (allows reload)

## Styling
- Use Angular Material `mat-card`, `mat-chip`, `mat-button`, `mat-spinner`
- Component SCSS only — no inline styles
- Accessible: ARIA labels on button and cards, keyboard navigable
- Clean, centred layout with a page title "Azure DevOps Projects" using Angular Material typography

## Notes
- Follow the system prompt at `docs/prompts/system-prompt.md` — standalone components, NgRx for all state, OnPush, smart/dumb pattern, no NgModules
- All async operations via NgRx effects only
- No direct HTTP calls from components