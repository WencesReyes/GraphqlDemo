namespace GraphqlDemo.API.Schema.Queries.Types
{
    public class CourseType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
