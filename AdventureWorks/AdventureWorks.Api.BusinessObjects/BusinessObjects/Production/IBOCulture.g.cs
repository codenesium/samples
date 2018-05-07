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

		POCOCulture Get(string cultureID);

		List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6adb394724994ed8492f59519e07a47f</Hash>
</Codenesium>*/