import { Component, OnInit } from '@angular/core';
import bookServices from './book.service';
import {Ibook} from '../entities/Ibook';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  
})
export class BookComponent implements OnInit {

  constructor(private bookService : bookServices) { }

  //books arr
  books : Ibook[] = [];

  //filters
  title = "";
  autor = '';
  spend = 0;

  applyFilters(): void{
    if(this.title !== '' || this.autor !=='' || this.spend !== 0){
      this.bookService.getByFilters(this.title,this.autor,this.spend).subscribe(
        {
          next: books=>{
            this.books = books.books;
          }
        }
      )
    }else{
      this.bookService.getBooks().subscribe({
        next: books =>{
          this.books = books.books;
        }
    });

    }

  }
  removeBook(id:number):void{
    this.bookService.removeBook(id).subscribe({
      next: response=>{
          if(response.code ===1000){
            this.bookService.getBooks().subscribe({
              next: books =>{
                this.books = books.books;
              }
          });
        }
      }
    })
  }
  ngOnInit(): void {
  this.bookService.getBooks().subscribe({
        next: books =>{
          this.books = books.books;
        }
    });

    
  }

}
