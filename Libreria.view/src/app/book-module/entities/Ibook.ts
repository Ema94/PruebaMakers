import {Ieditorial} from "./Ieditorial";

export interface Ibook{
    bookId : number;
    title:string;
    date:Date;
    spend:number;
    sugestedPrice:number;
    autor:string;
    editorialId:number;
    editorial:Ieditorial|null;
}

