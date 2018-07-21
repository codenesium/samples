using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface IPersonRefRepository
        {
                Task<PersonRef> Create(PersonRef item);

                Task Update(PersonRef item);

                Task Delete(int id);

                Task<PersonRef> Get(int id);

                Task<List<PersonRef>> All(int limit = int.MaxValue, int offset = 0);

                Task<SchemaBPerson> GetSchemaBPerson(int personBId);
        }
}

/*<Codenesium>
    <Hash>b7fcdf8cc4848cc8cfdaffffbafa3c1c</Hash>
</Codenesium>*/