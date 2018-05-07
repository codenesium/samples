using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		int Create(AddressTypeModel model);

		void Update(int addressTypeID,
		            AddressTypeModel model);

		void Delete(int addressTypeID);

		POCOAddressType Get(int addressTypeID);

		List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7331e1bd34849433bec581fd61dd4b69</Hash>
</Codenesium>*/