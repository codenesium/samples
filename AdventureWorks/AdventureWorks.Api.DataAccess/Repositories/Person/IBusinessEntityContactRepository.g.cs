using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IBusinessEntityContactRepository
	{
		Task<BusinessEntityContact> Create(BusinessEntityContact item);

		Task Update(BusinessEntityContact item);

		Task Delete(int businessEntityID);

		Task<BusinessEntityContact> Get(int businessEntityID);

		Task<List<BusinessEntityContact>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityContact>> ByContactTypeID(int contactTypeID, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityContact>> ByPersonID(int personID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>66931e61412b840e56c285cb39117d62</Hash>
</Codenesium>*/