import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module'; // Import the AppRoutingModule

import { AppComponent } from './app.component';
import { BookSearchComponent } from './components/book-search/book-search.component';


@NgModule({
  declarations: [
    AppComponent,
    BookSearchComponent // Replace with actual component declarations
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule // Import and include the AppRoutingModule here
    // Additional modules imported here as needed
  ],
  providers: [],
  bootstrap: [AppComponent] // Specify the root component
})
export class AppModule { }
