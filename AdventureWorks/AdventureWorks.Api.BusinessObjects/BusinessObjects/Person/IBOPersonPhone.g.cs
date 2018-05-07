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
		Task<CreateResponse<int>> Create(
			PersonPhoneModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PersonPhoneModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		POCOPersonPhone Get(int businessEntityID);

		List<POCOPersonPhone> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ffa35c6c3171c9aba0378b7b139378aa</Hash>
</Codenesium>*/