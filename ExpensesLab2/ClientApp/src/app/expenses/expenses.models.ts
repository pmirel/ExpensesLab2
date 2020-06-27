export interface Expense {
    id: number;
    description: string;
    sum: number;
    location: string;
    dateAdded: Date;
    currency: string;
    typeOfExpense: TypeOfExpense;
}

export enum TypeOfExpense {
    Food = 0,
    Utilities = 1,
    Transportation = 2,
    Outing = 3,
    Groceries = 4,
    Clothes = 5,
    Electronics = 6,
    Other = 7
}

