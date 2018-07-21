using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface IPersonRepository
        {
                Task<Person> Create(Person item);

                Task Update(Person item);

                Task Delete(int personId);

                Task<Person> Get(int personId);

                Task<List<Person>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>0106054c95f79d046a7c9bba0c8bc726</Hash>
</Codenesium>*/