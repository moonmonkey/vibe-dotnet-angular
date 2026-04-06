import { Component, Input, ChangeDetectionStrategy } from "@angular/core";
import { MatCardModule } from "@angular/material/card";
import { MatChipsModule } from "@angular/material/chips";
import { MatButtonModule } from "@angular/material/button";
import { Project } from "../../../models/project.model";

@Component({
    selector: "app-project-card",
    standalone: true,
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [MatCardModule, MatChipsModule, MatButtonModule],
    templateUrl: './project-card.component.html',
    styleUrl: './project-card.component.scss'
})
export class ProjectCardComponent {
    @Input({ required: true }) project!: Project;
}