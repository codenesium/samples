using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOVendor
	{
		Task<CreateResponse<int>> Create(
			VendorModel model);

		Task<ActionResponse> Update(int businessEntityID,
		                            VendorModel model);

		Task<ActionResponse> Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOVendor GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOVendor> GetWhereDirect(Expression<Func<EFVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2d0f248abf2e04f377a20f68217d2fcb</Hash>
</Codenesium>*/