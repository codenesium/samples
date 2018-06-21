using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPersonPhoneRepository
        {
                Task<PersonPhone> Create(PersonPhone item);

                Task Update(PersonPhone item);

                Task Delete(int businessEntityID);

                Task<PersonPhone> Get(int businessEntityID);

                Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PersonPhone>> ByPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>b090eac60c6285e7b46623a12b1d6348</Hash>
</Codenesium>*/