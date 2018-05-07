using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddressType
	{
		Task<CreateResponse<int>> Create(
			AddressTypeModel model);

		Task<ActionResponse> Update(int addressTypeID,
		                            AddressTypeModel model);

		Task<ActionResponse> Delete(int addressTypeID);

		POCOAddressType Get(int addressTypeID);

		List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bde82991d65e221d526db5afd4e28b7d</Hash>
</Codenesium>*/