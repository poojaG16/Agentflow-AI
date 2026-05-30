import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Parent } from "../pract/parent/parent";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Parent],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App {
  protected readonly title = signal('Frontend');
}
