namespace Library.Exceptions
{
    internal class BookIsAssignedException : Exception
    {
        internal BookIsAssignedException() : base("Книга уже выдана другому пользователю") { }
    }
}
