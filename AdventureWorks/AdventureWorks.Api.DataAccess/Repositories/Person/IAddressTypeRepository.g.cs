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

		Task<List<BusinessEntityAddress>> BusinessEntityAddressesByAddressTypeID(int addressTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a9c6ef15f4d0102b8e6d5b1578d4987b</Hash>
</Codenesium>*/