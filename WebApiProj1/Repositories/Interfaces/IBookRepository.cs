﻿using WebApiProj1.Models.Entities;

namespace WebApiProj1.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Books> CreateBook(Books model);
        Task<List<Books>> GetAllBooks();

        Task<Books> GetBooksById(int id);

        Task DeleteBookById(int id);

    }
}
