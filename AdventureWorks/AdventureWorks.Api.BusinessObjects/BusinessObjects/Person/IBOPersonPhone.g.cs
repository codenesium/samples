using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPersonPhone
	{
		Task<CreateResponse<POCOPersonPhone>> Create(
			ApiPersonPhoneModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            ApiPersonPhoneModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		Task<POCOPersonPhone> Get(int businessEntityID);

		Task<List<POCOPersonPhone>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOPersonPhone>> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>8d4eb48169c7e66ecf1df381531104e6</Hash>
</Codenesium>*/