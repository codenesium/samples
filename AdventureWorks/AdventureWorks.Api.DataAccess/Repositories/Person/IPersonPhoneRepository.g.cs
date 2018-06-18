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

                Task<List<PersonPhone>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<PersonPhone>> ByPhoneNumber(string phoneNumber);
        }
}

/*<Codenesium>
    <Hash>301ec641d7f53fe057ce40079a72c365</Hash>
</Codenesium>*/