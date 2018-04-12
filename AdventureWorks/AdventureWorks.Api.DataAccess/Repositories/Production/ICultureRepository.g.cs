using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		string Create(
			string name,
			DateTime modifiedDate);

		void Update(string cultureID,
		            string name,
		            DateTime modifiedDate);

		void Delete(string cultureID);

		Response GetById(string cultureID);

		POCOCulture GetByIdDirect(string cultureID);

		Response GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5e44f795ffd3c3103c54ebbec23d3882</Hash>
</Codenesium>*/