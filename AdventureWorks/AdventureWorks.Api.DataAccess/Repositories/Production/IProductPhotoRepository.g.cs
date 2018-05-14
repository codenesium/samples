using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		POCOProductPhoto Create(ApiProductPhotoModel model);

		void Update(int productPhotoID,
		            ApiProductPhotoModel model);

		void Delete(int productPhotoID);

		POCOProductPhoto Get(int productPhotoID);

		List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5805234354afb3c9dc6e264d609e320</Hash>
</Codenesium>*/