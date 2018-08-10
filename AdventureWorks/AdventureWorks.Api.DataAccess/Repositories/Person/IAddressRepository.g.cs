using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IAddressRepository
	{
		Task<Address> Create(Address item);

		Task Update(Address item);

		Task Delete(int addressID);

		Task<Address> Get(int addressID);

		Task<List<Address>> All(int limit = int.MaxValue, int offset = 0);

		Task<Address> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode);

		Task<List<Address>> ByStateProvinceID(int stateProvinceID);

		Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int addressID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>546764c9709c068b4bf4c261bcd78932</Hash>
</Codenesium>*/