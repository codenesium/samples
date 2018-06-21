using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IContactTypeRepository
        {
                Task<ContactType> Create(ContactType item);

                Task Update(ContactType item);

                Task Delete(int contactTypeID);

                Task<ContactType> Get(int contactTypeID);

                Task<List<ContactType>> All(int limit = int.MaxValue, int offset = 0);

                Task<ContactType> ByName(string name);

                Task<List<BusinessEntityContact>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>927168b633bad0347b8d3f7bb7429976</Hash>
</Codenesium>*/