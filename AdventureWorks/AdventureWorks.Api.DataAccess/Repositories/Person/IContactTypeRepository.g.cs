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

                Task<List<ContactType>> All(int limit = int.MaxValue, int offset = 0);

                Task<ContactType> ByName(string name);

                Task<List<BusinessEntityContact>> BusinessEntityContacts(int contactTypeID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a808b8a9e8aa4fda9b33e4355c973acf</Hash>
</Codenesium>*/