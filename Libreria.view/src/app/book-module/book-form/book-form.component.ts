import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import bookServices from '../book/book.service';
import { book } from '../entities/book';
import { Ibook } from '../entities/Ibook';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.css']
})
export class BookFormComponent implements OnInit {

  constructor(private route: ActivatedRoute,
              private router: Router,
              private bookService : bookServices) { }
  
  action:string = "Add";
  book : Ibook = new book();
  addOrUpdate():void{
    if(this.book.bookId !== 0){
      this.updateBook();
    }else{
      this.addBook();
    }
  }
  addBook():void{
    this.bookService.addBook(this.book).subscribe(
      {
        next:response=>{
           if(response.code === 1000){
            this.router.navigate(['/books']);
           }else{
             alert(response.Message);
           }
        }
      }
    )
  }
  updateBook():void{
    this.bookService.updateBook(this.book).subscribe(
      {
        next:response=>{
           if(response.code === 1000){
            this.router.navigate(['/books']);
           }else{
             alert(response.Message);
           }
        }
      }
    )
  }
  getBook(id:number):void{
    this.bookService.getById(id).subscribe({
      next:response=>{
        this.book = response.book
      }
    })
  }

  ngOnInit(): void {
    const param = this.route.snapshot.paramMap.get('id');
    if(param !== "0"){
      this.action = `Update`;
      const id = param;
      if(id != null){
        this.getBook(Number.parseInt(id));
      }
    }else{
      this.action='Add'
    }
  }

}
