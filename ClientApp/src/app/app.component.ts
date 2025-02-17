import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  template: `
    <h1>Angular and .NET MVC Integration</h1>
    <button (click)="getData()">Get Data</button>
    <button (click)="postData()">Post Data</button>
    <p>{{ response }}</p>
  `,
})
export class AppComponent {
  response: any;

  constructor(private http: HttpClient) { }

  getData() {
    this.http.get('http://localhost:5000/api/data').subscribe(
      (data) => {
        this.response = JSON.stringify(data); // Преобразуем объект в строку
      },
      (error) => {
        this.response = 'Error occurred!';
      }
    );
  }

  postData() {
    const data = { message: 'Hello from Angular!' };
    this.http.post('http://localhost:5000/api/data', data).subscribe(
      (response) => {
        this.response = JSON.stringify(response); // Преобразуем объект в строку
      },
      (error) => {
        this.response = 'Error occurred!';
      }
    );
  }
}
