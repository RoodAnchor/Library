namespace Library.Exceptions
{
    internal class AuthorNotFoundException : Exception
    {
        internal AuthorNotFoundException() : base("Автор не найден") { }
    }
}
