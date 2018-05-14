using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		POCOAddressType Create(ApiAddressTypeModel model);

		void Update(int addressTypeID,
		            ApiAddressTypeModel model);

		void Delete(int addressTypeID);

		POCOAddressType Get(int addressTypeID);

		List<POCOAddressType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOAddressType GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b95e7773ed85fda259d1f79815f10be2</Hash>
</Codenesium>*/