using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IBusinessEntityRepository
        {
                Task<BusinessEntity> Create(BusinessEntity item);

                Task Update(BusinessEntity item);

                Task Delete(int businessEntityID);

                Task<BusinessEntity> Get(int businessEntityID);

                Task<List<BusinessEntity>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<BusinessEntityContact>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0);

                Task<List<Person>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5281184ed7fd5d1cd5a82cf61602deee</Hash>
</Codenesium>*/