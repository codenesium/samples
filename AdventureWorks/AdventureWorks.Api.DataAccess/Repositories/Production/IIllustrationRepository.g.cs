using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IIllustrationRepository
	{
		int Create(string diagram,
		           DateTime modifiedDate);

		void Update(int illustrationID, string diagram,
		            DateTime modifiedDate);

		void Delete(int illustrationID);

		Response GetById(int illustrationID);

		POCOIllustration GetByIdDirect(int illustrationID);

		Response GetWhere(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOIllustration> GetWhereDirect(Expression<Func<EFIllustration, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>05d760719ae90d129c11f266f30e3369</Hash>
</Codenesium>*/