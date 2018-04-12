using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		int Create(
			int illustrationID,
			DateTime modifiedDate);

		void Update(int productModelID,
		            int illustrationID,
		            DateTime modifiedDate);

		void Delete(int productModelID);

		Response GetById(int productModelID);

		POCOProductModelIllustration GetByIdDirect(int productModelID);

		Response GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOProductModelIllustration> GetWhereDirect(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>62ccae565954d9eca19953daad5b314b</Hash>
</Codenesium>*/