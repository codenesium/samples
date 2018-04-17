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
		Task<CreateResponse<int>> Create(
			EmailAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            EmailAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOEmailAddress GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOEmailAddress> GetWhereDirect(Expression<Func<EFEmailAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8f76ee81499083a3278bae1f54ace66b</Hash>
</Codenesium>*/