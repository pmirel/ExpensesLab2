import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-expense-detail',
  templateUrl: './expense-detail.component.html',
  styleUrls: ['./expense-detail.component.css']
})
export class ExpenseDetailComponent implements OnInit {

    private expense: ExpenseWithDetails;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private route: ActivatedRoute,
        )
    {
        
    }

    loadExpense(expenseId: string) {
        this.http.get<ExpenseWithDetails>(this.baseUrl + 'api/Expenses/' + expenseId).subscribe(result => {


            this.expense = result;

            console.log(this.expense);
        }, error => console.error(error));
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.loadExpense(params.get('expenseId'));
        });
        
  }

}


interface ExpenseWithDetails {
    description: string;
    sum: number;
    location: string;
    dateAdded: Date;
    currency: string;
    typeOfExpense: string;
    comments: Comment[];
}

interface Comment {
    text: string;
    important: boolean;
    expenseId: number;
}
