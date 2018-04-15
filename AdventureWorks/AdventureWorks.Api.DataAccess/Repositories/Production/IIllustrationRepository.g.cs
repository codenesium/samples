using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		int Create(IllustrationModel model);

		void Update(int illustrationID,
		            IllustrationModel model);

		void Delete(int illustrationID);

		ApiResponse GetById(int illustrationID);

		POCOIllustration GetByIdDirect(int illustrationID);

		ApiResponse GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>43e61d9d2ec8547e3445f5a4003d0414</Hash>
</Codenesium>*/