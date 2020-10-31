using PruebaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaWebApp.Areas.BookArea.Models
{
    public static class BookManipulateResponsesFactory
    {
        public static BaseApiResponse Ok()
        {
            return new BaseApiResponse()
            {
                Code = 1000,
                Message = "Se realizo la transaccion correctamente"
            };
        }

        public static BaseApiResponse Error()
        {
            return new BaseApiResponse()
            {
                Code = 2000,
                Message = "Se produjo un error, vea en la descripcion para mas informacion"
            };
        }


    }

    public static class BookGetResponseFactory
    {
        public static BaseBookResponse Ok()
        {
            return new BaseBookResponse()
            {
                Code = 1000,
                Message = "Se realizo la transaccion correctamente"
            };
        }

        public static BaseBookResponse Error()
        {
            return new BaseBookResponse()
            {
                Code = 2000,
                Message = "Se produjo un error, vea en la descripcion para mas informacion"
            };
        }
    }
    public static class BookCollectionResponsesFactory
    {
        public static BookCollectionResponse Ok()
        {
            return new BookCollectionResponse()
            {
                Code = 1000,
                Message = "Se realizo la transaccion correctamente"
            };
        }

        public static BookCollectionResponse Error()
        {
            return new BookCollectionResponse()
            {
                Code = 2000,
                Message = "Se produjo un error, vea en la descripcion para mas informacion"
            };
        }
    }

}

