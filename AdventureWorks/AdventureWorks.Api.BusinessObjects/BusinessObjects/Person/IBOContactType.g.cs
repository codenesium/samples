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

		POCOContactType Get(int contactTypeID);

		List<POCOContactType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>75829f32c2d3208cdca15d5de4f74aec</Hash>
</Codenesium>*/