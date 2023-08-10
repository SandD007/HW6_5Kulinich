namespace MVC.Models.Response
{
    public class SomeTextResponse<T>
    {
        public T Id { get; set; } = default(T)!;
    }
}
