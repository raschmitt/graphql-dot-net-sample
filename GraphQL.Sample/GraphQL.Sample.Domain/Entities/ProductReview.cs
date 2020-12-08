namespace GraphQL.Sample.Domain.Entities
{
    //ToDo: utilizar setters privados
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }

        public ProductReview()
        {
        }

        public ProductReview(int productId, string title, string review)
        {
            ProductId = productId;
            Title = title;
            Review = review;
        }
    }
}