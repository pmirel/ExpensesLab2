import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    
    public expenses: Expense[];
    public comments: Comment[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    

      http.get<Expense[]>(baseUrl + 'api/Expenses').subscribe(result => {

          
          this.expenses = result;

          console.log(this.expenses);
      }, error => console.error(error));

  }
}


interface Expense {
    description: string;
    sum: number;
    location: string;
    dateAdded: Date;
    currency: string;
    typeOfExpense: TypeOfExpense;
}



enum TypeOfExpense {
    Food = 0,
    Utilities = 1,
    Transportation = 2,
    Outing = 3,
    Groceries = 4,
    Clothes = 5,
    Electronics = 6,
    Other = 7
}
