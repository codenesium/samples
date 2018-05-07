using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductPhotoRepository
	{
		int Create(ProductPhotoModel model);

		void Update(int productPhotoID,
		            ProductPhotoModel model);

		void Delete(int productPhotoID);

		POCOProductPhoto Get(int productPhotoID);

		List<POCOProductPhoto> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9f60720cdb333ced9082db5020587d73</Hash>
</Codenesium>*/