using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOContactType
	{
		Task<CreateResponse<int>> Create(
			ContactTypeModel model);

		Task<ActionResponse> Update(int contactTypeID,
		                            ContactTypeModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		ApiResponse GetById(int contactTypeID);

		POCOContactType GetByIdDirect(int contactTypeID);

		ApiResponse GetWhere(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOContactType> GetWhereDirect(Expression<Func<EFContactType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ecea242ca87c1c8284d4cdfe7c7b1b3f</Hash>
</Codenesium>*/