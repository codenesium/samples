using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IPersonPhoneRepository
        {
                Task<PersonPhone> Create(PersonPhone item);

                Task Update(PersonPhone item);

                Task Delete(int businessEntityID);

                Task<PersonPhone> Get(int businessEntityID);

                Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<PersonPhone>> GetPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>99cbd882e60b4feccd69c58268fe319e</Hash>
</Codenesium>*/