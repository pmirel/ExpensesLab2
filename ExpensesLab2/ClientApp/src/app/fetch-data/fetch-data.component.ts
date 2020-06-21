import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];
    public expenses: Expense[];
    public comments: Comment[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherForecast[]>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));

      http.get<Expense[]>(baseUrl + 'api/Expenses').subscribe(result => {

          
          this.expenses = result;

          console.log(this.expenses);
      }, error => console.error(error));

      http.get<Comment[]>(baseUrl + 'api/Comments').subscribe(result => {


          this.comments = result;

          console.log(this.comments);
      }, error => console.error(error));
  }
}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Expense {
    description: string;
    sum: number;
    location: string;
    dateAdded: Date;
    currency: string;
    
}

interface Comments {
    text: string;
    important: boolean;
    expenseId: number;
}
