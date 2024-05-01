namespace Library.Exceptions
{
    internal class GenreNotFoundException : Exception
    {
        internal GenreNotFoundException() : base("Жанр не найден") { }
    }
}
