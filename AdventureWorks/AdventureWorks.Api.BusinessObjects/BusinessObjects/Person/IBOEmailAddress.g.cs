using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOEmailAddress
	{
		Task<CreateResponse<ApiEmailAddressResponseModel>> Create(
			ApiEmailAddressRequestModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmailAddressRequestModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<ApiEmailAddressResponseModel> Get(int businessEntityID);

		Task<List<ApiEmailAddressResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiEmailAddressResponseModel>> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>24b7c6d48db976a38bce26868a080109</Hash>
</Codenesium>*/