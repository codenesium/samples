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

		Task<List<BusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<BusinessEntityContact>> GetContactTypeID(int contactTypeID);
		Task<List<BusinessEntityContact>> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>097a7ea890e798c3c9509cea03dc61e5</Hash>
</Codenesium>*/