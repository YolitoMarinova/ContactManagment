import { Component } from '@angular/core';
import { ContactComponent } from './components/contact/contact.component';

@Component({
  standalone: false,
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ContactManagment.UI';
}
