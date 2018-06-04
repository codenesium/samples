using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		Task<Address> Create(Address item);

		Task Update(Address item);

		Task Delete(int addressID);

		Task<Address> Get(int addressID);

		Task<List<Address>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Address> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);
		Task<List<Address>> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>8ecfe6e30d97ec606b807d2ece5b931b</Hash>
</Codenesium>*/