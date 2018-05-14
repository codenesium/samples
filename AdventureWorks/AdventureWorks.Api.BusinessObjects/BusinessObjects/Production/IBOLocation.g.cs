using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOLocation
	{
		Task<CreateResponse<POCOLocation>> Create(
			ApiLocationModel model);

		Task<ActionResponse> Update(short locationID,
		                            ApiLocationModel model);

		Task<ActionResponse> Delete(short locationID);

		POCOLocation Get(short locationID);

		List<POCOLocation> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOLocation GetName(string name);
	}
}

/*<Codenesium>
    <Hash>ea6498b3f57125401c28cc4bdb4e10b7</Hash>
</Codenesium>*/