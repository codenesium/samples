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
		Task<CreateResponse<POCOEmailAddress>> Create(
			ApiEmailAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiEmailAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOEmailAddress> Get(int businessEntityID);

		Task<List<POCOEmailAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOEmailAddress>> GetEmailAddress(string emailAddress1);
	}
}

/*<Codenesium>
    <Hash>165ef56b3ec1f913eb474a216ca6c6e8</Hash>
</Codenesium>*/