namespace Africuisine.Application.Data.Res
{
    public class ItemResponse<T> : Response where T : class
    {
        public T Item { get; set; }
    }
}
