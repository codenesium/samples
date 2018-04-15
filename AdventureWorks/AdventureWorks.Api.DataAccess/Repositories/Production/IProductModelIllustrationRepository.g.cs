using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		int Create(ProductModelIllustrationModel model);

		void Update(int productModelID,
		            ProductModelIllustrationModel model);

		void Delete(int productModelID);

		ApiResponse GetById(int productModelID);

		POCOProductModelIllustration GetByIdDirect(int productModelID);

		ApiResponse GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModelIllustration> GetWhereDirect(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e2d2f0f20220760813f5eb3d476edb4f</Hash>
</Codenesium>*/