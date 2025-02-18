import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@Component({
  selector: 'app-root',
  standalone: true, 
  imports: [
    CommonModule,
    MatCardModule,
    MatButtonModule,
    MatToolbarModule,
    MatListModule,
    MatIconModule,
  ],
  styles: [
    `
    .container {
      margin: 40px;
      padding: 20px;
    }

    .spacer {
      flex: 1 1 auto;
    }

    .item-card {
      display: flex;
      justify-content: space-between;
      align-items: center;
      border-bottom: 1px solid #eee;
      padding: 40px;
      cursor: pointer;
      transition: background-color 0.3s ease;

      &:hover {
        background-color: #008cf0;
      }
    }

    .item-content {
      display: flex;
      align-items: center;
      gap: 50px;
      flex: 1; 
    }

    .item-id {
      flex: 1; 
      text-align: center; 
      font-weight: 500;
    }

    mat-icon {
      color: #3f51b5;
    }

    mat-card {
      margin: 20px;
      padding: 30px;
      box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
      background-color: #eebef1;
    }

    button[mat-raised-button] {
      margin-top: 10px;
    }

    mat-list-item {
      align-items: center;
    }
  `,
  ],
   
  template: `
   <mat-toolbar color="primary">
  <span>Test Task for Infotecs</span>
  <span class="spacer"></span>
  <button mat-raised-button (click)="getData()">Выгрузить данные из генератора(Генерирует не больше 10, по 1 каждые 10 секунд)</button>
   <button mat-raised-button (click)="back()">Создать back up файл</button>
</mat-toolbar>

<mat-card *ngIf="response && !selectedItem" class="container">
  <mat-list>
    <mat-list-item *ngFor="let item of response" class="item-card">
      <div class="item-content" (click)="selectItem(item)">
        <mat-icon>description</mat-icon>
        <span class="item-id">ID: {{ item._id }}</span>
         <button mat-icon-button (click)="removeItem(item); $event.stopPropagation()">
        <mat-icon>delete</mat-icon>
      </button>
      </div>
     
    </mat-list-item>
  </mat-list>
</mat-card>

<mat-card *ngIf="selectedItem" class="container">
  <h2>Информация</h2>
  <mat-list>
    <mat-list-item>
      <mat-icon>person</mat-icon>
      <span><strong>Name:</strong> {{ selectedItem.name }}</span>
    </mat-list-item>
    <mat-list-item>
      <mat-icon>schedule</mat-icon>
      <span><strong>Start Time:</strong> {{ selectedItem.startTime | date:'medium' }}</span>
    </mat-list-item>
    <mat-list-item>
      <mat-icon>schedule</mat-icon>
      <span><strong>End Time:</strong> {{ selectedItem.endTime | date:'medium' }}</span>
    </mat-list-item>
    <mat-list-item>
      <mat-icon>code</mat-icon>
      <span><strong>Version:</strong> {{ selectedItem.version }}</span>
    </mat-list-item>
    <mat-list-item>
      <mat-icon>fingerprint</mat-icon>
      <span><strong>ID:</strong> {{ selectedItem._id }}</span>
    </mat-list-item>
  </mat-list>
  <button mat-raised-button color="primary" (click)="clearSelection()">Назад</button>
</mat-card>
  `,
})
export class AppComponent {
  response: any[] = []; 
  selectedItem: any = null;

  constructor(private http: HttpClient) { }

  getData() {
    this.http.get<any[]>('http://localhost:5000/api/data/get').subscribe(
      (data) => {
        this.response = data; 
        this.selectedItem = null; 
      },
      (error) => {
        this.response = [];
        console.error('Error occurred!', error);
      }
    );
  }

  back() {
    this.http.get('http://localhost:5000/api/data/BackUp').subscribe(
      (response) => {
        console.log('Post response:', response);
      },
      (error) => {
        console.error('Error occurred!', error);
      }
    );
  }
  selectItem(item: any) {
    this.selectedItem = item;
  }


  removeItem(item: any) {
   
    this.response = this.response.filter((i) => i._id !== item._id);

    
    this.http.post('http://localhost:5000/api/data/Remove', item).subscribe(
      (response) => {
        console.log('Post response:', response);
      },
      (error) => {
        console.error('Error occurred!', error);
      }
    );
  }

 
  clearSelection() {
    this.selectedItem = null;
  }
}
