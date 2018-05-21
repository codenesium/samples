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
		Task<CreateResponse<POCOProductPhoto>> Create(
			ApiProductPhotoModel model);

		Task<ActionResponse> Update(int productPhotoID,
		                            ApiProductPhotoModel model);

		Task<ActionResponse> Delete(int productPhotoID);

		Task<POCOProductPhoto> Get(int productPhotoID);

		Task<List<POCOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e009c7219cb2f2fca9495dd8ccc2366</Hash>
</Codenesium>*/