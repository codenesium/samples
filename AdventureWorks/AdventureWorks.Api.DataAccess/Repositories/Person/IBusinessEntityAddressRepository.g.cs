using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		Task<POCOBusinessEntityAddress> Create(ApiBusinessEntityAddressModel model);

		Task Update(int businessEntityID,
		            ApiBusinessEntityAddressModel model);

		Task Delete(int businessEntityID);

		Task<POCOBusinessEntityAddress> Get(int businessEntityID);

		Task<List<POCOBusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOBusinessEntityAddress>> GetAddressID(int addressID);
		Task<List<POCOBusinessEntityAddress>> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>506d2b176a4bfc8a8d7ad3edd9f91c3f</Hash>
</Codenesium>*/