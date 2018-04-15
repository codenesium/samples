using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductDescriptionRepository
	{
		int Create(ProductDescriptionModel model);

		void Update(int productDescriptionID,
		            ProductDescriptionModel model);

		void Delete(int productDescriptionID);

		ApiResponse GetById(int productDescriptionID);

		POCOProductDescription GetByIdDirect(int productDescriptionID);

		ApiResponse GetWhere(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductDescription> GetWhereDirect(Expression<Func<EFProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>937de0f1ac0961618f8cadf91c17d3b5</Hash>
</Codenesium>*/