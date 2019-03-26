using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IAddressTypeRepository
	{
		Task<AddressType> Create(AddressType item);

		Task Update(AddressType item);

		Task Delete(int addressTypeID);

		Task<AddressType> Get(int addressTypeID);

		Task<List<AddressType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<AddressType> ByName(string name);

		Task<AddressType> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>32047b4a51834d1fe5430e5b608c3246</Hash>
</Codenesium>*/