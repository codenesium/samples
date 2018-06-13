using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IContactTypeRepository
        {
                Task<ContactType> Create(ContactType item);

                Task Update(ContactType item);

                Task Delete(int contactTypeID);

                Task<ContactType> Get(int contactTypeID);

                Task<List<ContactType>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ContactType> GetName(string name);

                Task<List<BusinessEntityContact>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b2dc8356e58bd3b0f91fef5c0fc37ac5</Hash>
</Codenesium>*/