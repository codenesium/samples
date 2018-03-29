using System;
using System.Linq.Expressions;
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

		void GetById(int productModelID, Response response);

		void GetWhere(Expression<Func<EFProductModelIllustration, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>aa05c2b066149b222cd89dfdfadf54d6</Hash>
</Codenesium>*/