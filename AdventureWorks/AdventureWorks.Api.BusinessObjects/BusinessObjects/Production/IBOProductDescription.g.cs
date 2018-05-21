using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductDescription
	{
		Task<CreateResponse<POCOProductDescription>> Create(
			ApiProductDescriptionModel model);

		Task<ActionResponse> Update(int productDescriptionID,
		                            ApiProductDescriptionModel model);

		Task<ActionResponse> Delete(int productDescriptionID);

		Task<POCOProductDescription> Get(int productDescriptionID);

		Task<List<POCOProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c3b67a1e3479884c3232a83f61b7e7d</Hash>
</Codenesium>*/