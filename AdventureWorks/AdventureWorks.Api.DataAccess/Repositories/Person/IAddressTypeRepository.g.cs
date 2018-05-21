using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		Task<POCOAddressType> Create(ApiAddressTypeModel model);

		Task Update(int addressTypeID,
		            ApiAddressTypeModel model);

		Task Delete(int addressTypeID);

		Task<POCOAddressType> Get(int addressTypeID);

		Task<List<POCOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOAddressType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>66fc6c83e8d11c56263bc13c676a900a</Hash>
</Codenesium>*/