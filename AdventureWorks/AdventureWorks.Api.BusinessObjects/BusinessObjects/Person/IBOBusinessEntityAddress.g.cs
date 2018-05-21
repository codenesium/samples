using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityAddress
	{
		Task<CreateResponse<POCOBusinessEntityAddress>> Create(
			ApiBusinessEntityAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiBusinessEntityAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOBusinessEntityAddress> Get(int businessEntityID);

		Task<List<POCOBusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOBusinessEntityAddress>> GetAddressID(int addressID);
		Task<List<POCOBusinessEntityAddress>> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>e5da3c0ab52276b7d16458c9dbd0b510</Hash>
</Codenesium>*/