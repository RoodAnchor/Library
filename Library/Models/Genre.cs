﻿namespace Library.Models
{
    public class Genre
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
