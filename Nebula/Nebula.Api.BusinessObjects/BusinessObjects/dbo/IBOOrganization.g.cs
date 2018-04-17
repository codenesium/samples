using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public interface IBOOrganization
	{
		Task<CreateResponse<int>> Create(
			OrganizationModel model);

		Task<ActionResponse> Update(int id,
		                            OrganizationModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOOrganization GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOOrganization> GetWhereDirect(Expression<Func<EFOrganization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e2be07136ce330a73d47557386b580d9</Hash>
</Codenesium>*/