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

		POCOCulture Get(string cultureID);

		List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>132aef0ee9abed588a6cc9fefc9bd8f2</Hash>
</Codenesium>*/