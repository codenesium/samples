using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(string cultureID);

		POCOCulture GetByIdDirect(string cultureID);

		Response GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b9b5b14bfb9e5b978c78fc3ac9398879</Hash>
</Codenesium>*/