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

		Task<List<BusinessEntityContact>> ByContactTypeID(int contactTypeID);

		Task<List<BusinessEntityContact>> ByPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>7dfd4664822efec2c6305aa6f2347cf4</Hash>
</Codenesium>*/