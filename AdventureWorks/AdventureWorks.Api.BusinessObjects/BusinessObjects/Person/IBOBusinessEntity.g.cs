using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntity
	{
		Task<CreateResponse<int>> Create(
			BusinessEntityModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOBusinessEntity GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntity> GetWhereDirect(Expression<Func<EFBusinessEntity, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3d70af2d216a88d69b1f60f6101001d0</Hash>
</Codenesium>*/