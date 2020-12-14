import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators';
import {Ibook} from "../entities/Ibook";

@Injectable({
    providedIn: 'root'
})
export default class bookServices{
    constructor(private http: HttpClient){}

    getBooks(){
        let findAllUrl='http://localhost:58324/api/book/ByFilters/';
        return this.http.get<any>(findAllUrl);
    }

    getByFilters(title:string,autor:string,spend:number){
        let findByFiltersUrl='http://localhost:58324/api/book/ByFilters/?';
        
        if(title !== ''){
            findByFiltersUrl += `title=${title}&`;
        }
        if(autor !== ''){
            findByFiltersUrl += `autor=${autor}&`;
        }
        if(spend !== 0){
            findByFiltersUrl += `spend=${spend}&`;
        }

        return this.http.get<any>(findByFiltersUrl);
    }

    getById(id:number){
        let findByIdUrl=`http://localhost:58324/api/book/ById/?id=${id}`;
        return this.http.get<any>(findByIdUrl);

    }

    addBook(book:Ibook){
        let addUrl = 'http://localhost:58324/api/book/'
        return this.http.post<any>(addUrl,book);
    }

    updateBook(book:Ibook){
        let addUrl = 'http://localhost:58324/api/book/'
        return this.http.put<any>(addUrl,book);
    }

    removeBook(id:number){
        let removeUrl= `http://localhost:58324/api/book/?bookId=${id}`;
        return this.http.delete<any>(removeUrl);
    }
}