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

		Task<List<BusinessEntityAddress>> ByAddressID(int addressID, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityAddress>> ByAddressTypeID(int addressTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>667180ea9c2898956fc191928ed68d4b</Hash>
</Codenesium>*/