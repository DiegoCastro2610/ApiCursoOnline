namespace CursoOnline.Exceptions
{
    public class DomainExcepition
    {
        public class DomainException : Exception
        {
            public DomainException(string mensagem) : base(mensagem)
            { }
        }
    }
}
