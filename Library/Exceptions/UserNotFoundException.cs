namespace Library.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        internal UserNotFoundException() : base("Пользователь не найден") { }
    }
}
