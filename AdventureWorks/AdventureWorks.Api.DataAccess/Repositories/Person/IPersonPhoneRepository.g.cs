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

                Task<List<PersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<PersonPhone>> GetPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>a544a54764dfeb656943889245924cfc</Hash>
</Codenesium>*/