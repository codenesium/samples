using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		Task<BusinessEntityAddress> Create(BusinessEntityAddress item);

		Task Update(BusinessEntityAddress item);

		Task Delete(int businessEntityID);

		Task<BusinessEntityAddress> Get(int businessEntityID);

		Task<List<BusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<BusinessEntityAddress>> GetAddressID(int addressID);
		Task<List<BusinessEntityAddress>> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>4a64490759473b6fdf23a744fe236b78</Hash>
</Codenesium>*/