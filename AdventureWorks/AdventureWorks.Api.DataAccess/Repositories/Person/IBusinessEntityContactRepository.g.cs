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

                Task<List<BusinessEntityContact>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<BusinessEntityContact>> GetContactTypeID(int contactTypeID);
                Task<List<BusinessEntityContact>> GetPersonID(int personID);
        }
}

/*<Codenesium>
    <Hash>67c6646c353f1f4dea63e1125eded3dc</Hash>
</Codenesium>*/