using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductProductPhotoRepository
	{
		POCOProductProductPhoto Create(ApiProductProductPhotoModel model);

		void Update(int productID,
		            ApiProductProductPhotoModel model);

		void Delete(int productID);

		POCOProductProductPhoto Get(int productID);

		List<POCOProductProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>82ffbc5324870613686992d0c82d434f</Hash>
</Codenesium>*/