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

		POCOIllustration Get(int illustrationID);

		List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c147fe70f6a41820e34ecffdae9197e1</Hash>
</Codenesium>*/