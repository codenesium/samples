using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		Task<BusinessEntityAddress> Create(BusinessEntityAddress item);

		Task Update(BusinessEntityAddress item);

		Task Delete(int businessEntityID);

		Task<BusinessEntityAddress> Get(int businessEntityID);

		Task<List<BusinessEntityAddress>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityAddress>> ByAddressID(int addressID);

		Task<List<BusinessEntityAddress>> ByAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>d4db605315c24ab4befb177ae69caddd</Hash>
</Codenesium>*/