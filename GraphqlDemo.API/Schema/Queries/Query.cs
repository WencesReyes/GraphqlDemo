using Bogus;
using GraphqlDemo.API.Schema.Queries.Types;

namespace GraphqlDemo.API.Schema.Queries
{
    public class Query
    {
        private readonly Faker<CourseType> _fakerCourseType;
        private readonly Faker<StudentType> _fakerStudentType;
        public Query()
        {
            _fakerStudentType = new Faker<StudentType>()
                 .RuleForType(typeof(string), f => f.Name.FullName())
                 .RuleFor(s => s.Id, f => Guid.NewGuid());
            _fakerCourseType = new Faker<CourseType>()
                 .RuleForType(typeof(string), f => f.Name.FullName())
                 .RuleFor(c => c.Id, f => Guid.NewGuid())
                 .RuleFor(c => c.Students, f => _fakerStudentType.Generate(3));
        }

        public async Task<IEnumerable<CourseType>> GetCoursesAsync()
        {
            await Task.Delay(1000);
            return _fakerCourseType.Generate(5);
        }

        public CourseType GetCourseById(Guid id)
        {
            var course = _fakerCourseType.Generate();
            course.Id = id;

            return course;
        }

        [GraphQLDeprecated("This query is deprecated")]
        public string HelloWorld => "Hello!";
    }
}
