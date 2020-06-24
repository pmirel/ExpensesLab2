import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    
    public expenses: Expense[];
    public name: string = "test";

    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
        this.loadExpenses();
    }


    loadExpenses() {
        this.http.get<Expense[]>(this.baseUrl + 'api/Expenses').subscribe(result => {


            this.expenses = result;

            console.log(this.expenses);
        }, error => console.error(error));
    }

    delete(expenseId: string) {
        if (confirm('Are you sure you want to delete the expense with id ' + expenseId + '?')) {
            this.http.delete(this.baseUrl + 'api/Expenses/' + expenseId)
                .subscribe
                (
                    result => {
                        alert('Expense successfully deleted!');
                        this.loadExpenses();
                    },
                    error => alert('Cannot delete expense - maybe it has comments?')
                )
        }
    }
}




interface Expense {
    id: number;
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
