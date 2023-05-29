using GraphqlDemo.API.Schema.Mutations.Types;
using GraphqlDemo.API.Schema.Queries.Types;

namespace GraphqlDemo.API.Schema.Mutations
{
    public class Mutation
    {
        private readonly List<CourseType> _courses;
        public Mutation()
        {
            _courses = new List<CourseType>();
        }
        public CourseResponse AddCourse(AddCourseInput courseRequest)
        {
            var newCourse = new CourseType()
            {
                Id = Guid.NewGuid(),
                Name = courseRequest.Name,
            };

            _courses.Add(newCourse);

            return new CourseResponse { Id = newCourse.Id };
        }

        public CourseResponse UpdateCourse(UpdateCourseInput courseRequest)
        {
            var course = _courses.Find(c => c.Id == courseRequest.Id);

            if (course == null)
                throw new GraphQLException("Course not found");

            course.Name = courseRequest.Name;

            return new CourseResponse { Id = course.Id };
        }

        public bool DeleteCourse(Guid id)
        {
            var course = _courses.Find(c => c.Id == id);

            if (course == null)
                throw new GraphQLException("Course not found");

            _courses.Remove(course);

            return true;
        }
    }
}
