using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICultureRepository
	{
		POCOCulture Create(ApiCultureModel model);

		void Update(string cultureID,
		            ApiCultureModel model);

		void Delete(string cultureID);

		POCOCulture Get(string cultureID);

		List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCulture GetName(string name);
	}
}

/*<Codenesium>
    <Hash>37e8ac122acb82932c9b52eb3f959dc0</Hash>
</Codenesium>*/