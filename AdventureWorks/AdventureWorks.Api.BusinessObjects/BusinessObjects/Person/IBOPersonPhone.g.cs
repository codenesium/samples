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

		POCOPersonPhone Get(int businessEntityID);

		List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonPhone> GetPhoneNumber(string phoneNumber);
	}
}

/*<Codenesium>
    <Hash>8c2747692983cb7c9b796fd851fe73c3</Hash>
</Codenesium>*/