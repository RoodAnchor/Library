namespace Library.Exceptions
{
    internal class BookNotFoundException : Exception
    {
        internal BookNotFoundException() : base("Книга не найдена") { }
    }
}
