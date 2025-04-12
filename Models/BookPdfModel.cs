using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Riid.functions;

namespace Riid.Models
{
    public class BookPdfModel
    {
        [Key]
        public long Id { get; set; }
        public string Password { get; set; }

        public long Fk_book { get; set; }

        public BookModel Book { get; set; }

        private BookPdfModel() {}

        //To create a bookpdf object with a hashed password
        public static BookPdfModel Create(long fk_book)
        {
            var passwordHasher = new PasswordHasher<BookPdfModel>();
            var randomPassword = CodeGenerator.GenerateSecureCode();

            var newBookPdf = new BookPdfModel
            {
                Fk_book = fk_book
            };

            newBookPdf.Password = passwordHasher.HashPassword(newBookPdf, randomPassword);

            return newBookPdf;
        }
        
    }
}