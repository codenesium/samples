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
		Task<CreateResponse<POCOContactType>> Create(
			ApiContactTypeModel model);

		Task<ActionResponse> Update(int contactTypeID,
		                            ApiContactTypeModel model);

		Task<ActionResponse> Delete(int contactTypeID);

		POCOContactType Get(int contactTypeID);

		List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOContactType GetName(string name);
	}
}

/*<Codenesium>
    <Hash>fa87ecbbbea592d1dd156caad86115ef</Hash>
</Codenesium>*/