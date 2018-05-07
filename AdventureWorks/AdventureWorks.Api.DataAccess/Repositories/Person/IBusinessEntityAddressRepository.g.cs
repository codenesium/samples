using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		int Create(BusinessEntityAddressModel model);

		void Update(int businessEntityID,
		            BusinessEntityAddressModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntityAddress Get(int businessEntityID);

		List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b8b4cc7e52e5b5dcc3f3bd1cb0555539</Hash>
</Codenesium>*/