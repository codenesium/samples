using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IProductModelIllustrationRepository
	{
		int Create(int illustrationID,
		           DateTime modifiedDate);

		void Update(int productModelID, int illustrationID,
		            DateTime modifiedDate);

		void Delete(int productModelID);

		Response GetById(int productModelID);

		POCOProductModelIllustration GetByIdDirect(int productModelID);

		Response GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOProductModelIllustration> GetWhereDirect(Expression<Func<EFProductModelIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3814a2223ee96268d6a53a96dc4c23e2</Hash>
</Codenesium>*/