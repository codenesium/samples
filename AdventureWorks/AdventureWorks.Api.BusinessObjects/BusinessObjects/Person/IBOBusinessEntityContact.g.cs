using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityContact
	{
		Task<CreateResponse<int>> Create(
			BusinessEntityContactModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityContactModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOBusinessEntityContact GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityContact> GetWhereDirect(Expression<Func<EFBusinessEntityContact, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bc1d818ae1acfe4358a2db0333f68473</Hash>
</Codenesium>*/