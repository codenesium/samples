using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		string Create(string name,
		              DateTime modifiedDate);

		void Update(string cultureID, string name,
		            DateTime modifiedDate);

		void Delete(string cultureID);

		void GetById(string cultureID, Response response);

		void GetWhere(Expression<Func<EFCulture, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a885c2caf457592367e5aa7dc2c73beb</Hash>
</Codenesium>*/