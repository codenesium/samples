using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductModelIllustration
	{
		Task<CreateResponse<POCOProductModelIllustration>> Create(
			ApiProductModelIllustrationModel model);

		Task<ActionResponse> Update(int productModelID,
		                            ApiProductModelIllustrationModel model);

		Task<ActionResponse> Delete(int productModelID);

		POCOProductModelIllustration Get(int productModelID);

		List<POCOProductModelIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ae67fd2a782ba259b373b830d6efd142</Hash>
</Codenesium>*/