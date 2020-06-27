import { Expense } from "./expenses.models";

export interface PaginatedExpenses   {
    currentPage: number;
    totalItems: number;
    itemsPerPage: number;
    totalPages: number;
    items: Expense[];  
}



