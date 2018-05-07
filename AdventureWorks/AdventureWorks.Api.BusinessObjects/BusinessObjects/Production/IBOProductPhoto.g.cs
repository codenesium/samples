using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOProductPhoto
	{
		Task<CreateResponse<int>> Create(
			ProductPhotoModel model);

		Task<ActionResponse> Update(int productPhotoID,
		                            ProductPhotoModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		POCOProductPhoto Get(int productPhotoID);

		List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3574ea6fc108bc9429789655c2a5bca4</Hash>
</Codenesium>*/