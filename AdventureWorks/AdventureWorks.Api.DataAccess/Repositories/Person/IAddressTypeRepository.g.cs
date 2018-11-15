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

		Task<List<AddressType>> All(int limit = int.MaxValue, int offset = 0);

		Task<AddressType> ByName(string name);

		Task<AddressType> ByRowguid(Guid rowguid);
	}
}

/*<Codenesium>
    <Hash>111deee084b9baf9a29c74c4bf28bfa7</Hash>
</Codenesium>*/