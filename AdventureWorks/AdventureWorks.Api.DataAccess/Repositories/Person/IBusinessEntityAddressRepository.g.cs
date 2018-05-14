using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		POCOBusinessEntityAddress Create(ApiBusinessEntityAddressModel model);

		void Update(int businessEntityID,
		            ApiBusinessEntityAddressModel model);

		void Delete(int businessEntityID);

		POCOBusinessEntityAddress Get(int businessEntityID);

		List<POCOBusinessEntityAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOBusinessEntityAddress> GetAddressID(int addressID);
		List<POCOBusinessEntityAddress> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>fa69381c85e0f6e0791b26c6c7b1590c</Hash>
</Codenesium>*/