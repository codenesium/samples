using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		Task<POCOAddress> Create(ApiAddressModel model);

		Task Update(int addressID,
		            ApiAddressModel model);

		Task Delete(int addressID);

		Task<POCOAddress> Get(int addressID);

		Task<List<POCOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);
		Task<List<POCOAddress>> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>3687d6a9b849603892c6b7b576413784</Hash>
</Codenesium>*/