import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { environment } from './environments/environment.development';
import { MusicService } from './services/music.services';
import { Music } from './models/music.model';

@Component({
  selector: 'app-root',
  standalone: true, // 🚀 Standalone ativado
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'firstCRUD';

  musicas: Music[] = [];

  constructor(private musicSercive: MusicService) {
    this.obterMusicasCadastradas();
  }

  obterMusicasCadastradas() {
    this.musicSercive
      .showMusics()
      .subscribe((musicas) => (this.musicas = musicas));
  }
}
