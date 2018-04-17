using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOBusinessEntityAddress
	{
		Task<CreateResponse<int>> Create(
			BusinessEntityAddressModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            BusinessEntityAddressModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOBusinessEntityAddress GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityAddress> GetWhereDirect(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c9218ea1405447c9d5f04dcda5e84d62</Hash>
</Codenesium>*/