using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCulture
	{
		Task<CreateResponse<string>> Create(
			CultureModel model);

		Task<ActionResponse> Update(string cultureID,
		                            CultureModel model);

		Task<ActionResponse> Delete(string cultureID);

		ApiResponse GetById(string cultureID);

		POCOCulture GetByIdDirect(string cultureID);

		ApiResponse GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>942c6cde02670054d7e1e7ab2c993cd7</Hash>
</Codenesium>*/