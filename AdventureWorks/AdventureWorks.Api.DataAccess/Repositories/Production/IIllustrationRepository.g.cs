using System;
using System.Linq.Expressions;
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

		void GetById(int illustrationID, Response response);

		void GetWhere(Expression<Func<EFIllustration, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0fe5cb412f10cb25edab9a7448d7f1e5</Hash>
</Codenesium>*/