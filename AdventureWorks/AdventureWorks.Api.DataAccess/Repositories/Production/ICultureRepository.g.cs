using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		string Create(CultureModel model);

		void Update(string cultureID,
		            CultureModel model);

		void Delete(string cultureID);

		ApiResponse GetById(string cultureID);

		POCOCulture GetByIdDirect(string cultureID);

		ApiResponse GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>87f60383681764708b652e11d71c508a</Hash>
</Codenesium>*/