using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>49bd45acc48b9dcec8bf838d16864955</Hash>
</Codenesium>*/