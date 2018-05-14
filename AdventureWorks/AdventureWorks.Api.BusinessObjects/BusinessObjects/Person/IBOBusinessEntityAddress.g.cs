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

		POCOBusinessEntityAddress Get(int businessEntityID);

		List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityAddress> GetAddressID(int addressID);
		List<POCOBusinessEntityAddress> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>33bc002a865fb01ecebbae4d443a5fb5</Hash>
</Codenesium>*/