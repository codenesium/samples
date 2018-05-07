using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityContactRepository
	{
		int Create(BusinessEntityContactModel model);

		void Update(int businessEntityID,
		            BusinessEntityContactModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntityContact Get(int businessEntityID);

		List<POCOBusinessEntityContact> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>16c79576d5bee5056c3df529991d6d03</Hash>
</Codenesium>*/