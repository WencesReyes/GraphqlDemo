namespace GraphqlDemo.API.Schema.Queries.Types
{
    public class StudentType
    {
        public Guid Id { get; set; }
        [GraphQLName("Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
