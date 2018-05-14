using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		POCOPassword Create(ApiPasswordModel model);

		void Update(int businessEntityID,
		            ApiPasswordModel model);

		void Delete(int businessEntityID);

		POCOPassword Get(int businessEntityID);

		List<POCOPassword> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>23e2c1cffa36cc0eaf1348ae03167228</Hash>
</Codenesium>*/