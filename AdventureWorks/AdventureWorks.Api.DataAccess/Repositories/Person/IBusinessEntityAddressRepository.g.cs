using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IBusinessEntityAddressRepository
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
    <Hash>808ca48081fb48e76cc213fa62980b6d</Hash>
</Codenesium>*/