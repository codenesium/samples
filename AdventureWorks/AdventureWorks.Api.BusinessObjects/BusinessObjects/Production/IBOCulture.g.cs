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
		Task<CreateResponse<POCOCulture>> Create(
			ApiCultureModel model);

		Task<ActionResponse> Update(string cultureID,
		                            ApiCultureModel model);

		Task<ActionResponse> Delete(string cultureID);

		POCOCulture Get(string cultureID);

		List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCulture GetName(string name);
	}
}

/*<Codenesium>
    <Hash>19ee88094a026cd2eed92a877db39168</Hash>
</Codenesium>*/