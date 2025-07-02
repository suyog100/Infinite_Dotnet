﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiProj1.Models;
using WebApiProj1.Models.DTOs;
using WebApiProj1.Models.Entities;
using WebApiProj1.Services;
using WebApiProj1.Services.Interfaces;

namespace WebApiProj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(AddBooksDTO model)
        {
            var res = await _bookService.AddBook(model);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetBooks()
        {
            var res = await _bookService.GetAllBooks();
            return Ok(res);
        }

        [HttpGet("books/{id}")]
        public async Task<GenericRes<Books>> GetBooksById(int id)
        {
            var result = await _bookService.GetBooksById(id);
            return result;
        }

    }
}
