using Rise.Assessment.Database.Entities;
using Rise.Assessment.Database.Repositories.Base;

namespace Rise.Assessment.Database.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(RiseDbContext context) : base(context)
        {
            Entities = context.Persons;
        }
    }
}
