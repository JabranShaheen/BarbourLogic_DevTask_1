import { Component } from '@angular/core';
import { Book } from '../../models/book';
import { BookService } from '../../../services/book.service';

@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.css']
})
export class BookSearchComponent {
  title: string = '';
  author: string = '';
  isbn: string = '';
  books: Book[] = [];

  constructor(private bookService: BookService) { }

  onSearch(): void {
    this.bookService.searchBooks(this.title, this.author, this.isbn)
      .subscribe((books: Book[]) => {
        this.books = books;
      });
  }
}
