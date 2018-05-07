using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		int Create(BusinessEntityModel model);

		void Update(int businessEntityID,
		            BusinessEntityModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntity Get(int businessEntityID);

		List<POCOBusinessEntity> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fbeaafeacd2153ff563b9e11b66c549b</Hash>
</Codenesium>*/