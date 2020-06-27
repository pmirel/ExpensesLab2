import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ExpensesService } from '../expenses.service';
import { Expense, TypeOfExpense } from '../expenses.models';

@Component({
  selector: 'app-expenses-edit',
  templateUrl: './expenses-edit.component.html',
  styleUrls: ['./expenses-edit.component.css']
})
export class ExpensesEditComponent implements OnInit {

    private routerLink: string = '../list';

    private expenseID: number;

    private isEdit: boolean = false;

    public formGroup: FormGroup;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private expensesService: ExpensesService,
        private formBuilder: FormBuilder) { }

    ngOnInit() {

        this.expenseID = parseInt(this.route.snapshot.params['id']);

        if (this.expenseID) {
            this.routerLink = '../../list';

            this.expensesService.getExpense(this.expenseID).subscribe(res => {
                this.initForm(res);
                this.isEdit = true;
            });
        }
        else {
            this.initForm(<Expense>{});
        }
    }

    save() {
        Object.keys(this.formGroup.controls).forEach(control => {
            this.formGroup.get(control).markAsTouched();
        });

        if (this.formGroup.valid) {
            let expense = this.formGroup.value as Expense;
            expense.typeOfExpense = TypeOfExpense.Other;

            if (this.isEdit) {
                expense.id = this.expenseID;

                this.expensesService.modifyExpense(expense).subscribe(res => {
                    this.router.navigate(['/expenses']);
                });
            } else {

                this.expensesService.saveExpense(expense).subscribe(res => {
                    this.router.navigate(['/expenses']);
                });
            }
        }
    }

    initForm(expense: Expense) {
        this.formGroup = this.formBuilder.group({
            
            description: [expense.description, Validators.required],
            sum: [expense.sum, Validators.required],
            location: [expense.location, Validators.required],
            dateAdded: [expense.dateAdded, [Validators.required]],
            currency: [expense.currency, Validators.required],

        });
    }

}


