import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../app/models/book';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  private apiUrl = 'https://localhost:7016/api/Books';  // Update this to your API endpoint
  
  constructor(private http: HttpClient) { }

  searchBooks(title: string, author: string, isbn: string): Observable<Book[]> {
    const params: any = {};
    if (title) params.title = title;
    if (author) params.author = author;
    if (isbn) params.isbn = isbn;

    return this.http.get<Book[]>(`${this.apiUrl}/search`, { params });
  }
}
