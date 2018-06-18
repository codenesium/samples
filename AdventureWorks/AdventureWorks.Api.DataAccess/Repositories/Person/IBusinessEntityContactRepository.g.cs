using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IBusinessEntityContactRepository
        {
                Task<BusinessEntityContact> Create(BusinessEntityContact item);

                Task Update(BusinessEntityContact item);

                Task Delete(int businessEntityID);

                Task<BusinessEntityContact> Get(int businessEntityID);

                Task<List<BusinessEntityContact>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<BusinessEntityContact>> ByContactTypeID(int contactTypeID);
                Task<List<BusinessEntityContact>> ByPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>dc81e4583f0c48c4bbf4e47e36efb3b8</Hash>
</Codenesium>*/