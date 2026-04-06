import { Component, Input, ChangeDetectionStrategy } from "@angular/core";
import { Project } from "../../../models/project.model";
import { ProjectCardComponent } from "../project-card/project-card.component";

@Component({
    selector: "app-project-list",
    standalone: true,
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [ProjectCardComponent],
    templateUrl: "./project-list.component.html",
    styleUrls: ["./project-list.component.scss"],
})
export class ProjectListComponent {
    @Input({ required: true }) projects!: Project[];
}