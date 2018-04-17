using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOIllustration
	{
		Task<CreateResponse<int>> Create(
			IllustrationModel model);

		Task<ActionResponse> Update(int illustrationID,
		                            IllustrationModel model);

		Task<ActionResponse> Delete(int illustrationID);

		ApiResponse GetById(int illustrationID);

		POCOIllustration GetByIdDirect(int illustrationID);

		ApiResponse GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a645a78c2c55ddbd8d1279a523b4ee7</Hash>
</Codenesium>*/