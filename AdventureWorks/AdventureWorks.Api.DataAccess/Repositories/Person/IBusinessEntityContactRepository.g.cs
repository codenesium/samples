using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityContactRepository
	{
		POCOBusinessEntityContact Create(ApiBusinessEntityContactModel model);

		void Update(int businessEntityID,
		            ApiBusinessEntityContactModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntityContact Get(int businessEntityID);

		List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityContact> GetContactTypeID(int contactTypeID);
		List<POCOBusinessEntityContact> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>e25e5e9f6a8b41da02f3e1063619ee54</Hash>
</Codenesium>*/