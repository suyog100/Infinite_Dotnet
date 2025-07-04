﻿using WebApiProj1.Models;
using WebApiProj1.Models.DTOs;
using WebApiProj1.Models.Entities;
using WebApiProj1.Repositories.Interfaces;
using WebApiProj1.Services.Interfaces;

namespace WebApiProj1.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        public BookService(IBookRepository repo)
        {
            _repo = repo;   
        }

        public async Task<GenericRes<Books>> AddBook(AddBooksDTO model)
        {
            var reqModel = new Books
            {
                BookName = model.BookName,
                BookPrice = model.BookPrice
            };

            var res = await _repo.CreateBook(reqModel);

            if (res is not null)
            {
                return new GenericRes<Books>
                {
                    Data = res,
                    Message = "Book Added"
                };
            }

            return new GenericRes<Books>
            {
                Data = null,
                Message = "Failed to add book"
            };
        }

        public async Task<GenericRes<List<Books>>> GetAllBooks()
        {
            var res = await _repo.GetAllBooks();
            return new GenericRes<List<Books>>
            {
                Data = res,
                Message = "All Books Listed"
            };
        }

        public async Task<GenericRes<Books>> GetBooksById( int id)
        {
            var res = await _repo.GetBooksById(id);
            return new GenericRes<Books>
            {
                Data = res,
                Message = "All Books Listed"
            };
        }

        public async Task<GenericRes<string>> DeleteBookById(int id)
        {
            await _repo.DeleteBookById(id);
            return new GenericRes<string>()
            {
                Data = null,
                Message = "Delete Successfully"
            };
        }
    }
}
