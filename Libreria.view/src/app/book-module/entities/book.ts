import { Ieditorial } from "./Ieditorial";
import { Ibook } from "./Ibook";
import { editorial } from "./editorial";

export class book implements Ibook{
    constructor(){}
    bookId: number=0;
    title: string='';
    date: Date=new Date();
    spend: number =0;
    sugestedPrice: number=0;
    autor: string='';
    editorialId: number=1;
    editorial: Ieditorial | null=null;

}