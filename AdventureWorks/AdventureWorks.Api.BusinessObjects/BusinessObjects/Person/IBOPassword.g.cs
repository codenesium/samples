using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOPassword
	{
		Task<CreateResponse<int>> Create(
			PasswordModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            PasswordModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPassword GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPassword> GetWhereDirect(Expression<Func<EFPassword, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e72323286fb40a07d236f3f9f291b8d</Hash>
</Codenesium>*/