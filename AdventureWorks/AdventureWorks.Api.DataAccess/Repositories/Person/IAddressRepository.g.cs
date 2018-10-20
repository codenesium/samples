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

		Task<List<Address>> ByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityAddress>> BusinessEntityAddressesByAddressID(int addressID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>5ca155679ee6afc51d18a674bb1c1668</Hash>
</Codenesium>*/