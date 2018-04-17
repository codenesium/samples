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

		ApiResponse GetById(int businessEntityID);

		POCOPersonPhone GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonPhone> GetWhereDirect(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6dad73a9a930fc7454cd68b764ef8795</Hash>
</Codenesium>*/