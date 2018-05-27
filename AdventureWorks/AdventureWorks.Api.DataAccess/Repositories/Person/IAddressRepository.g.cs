using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		Task<DTOAddress> Create(DTOAddress dto);

		Task Update(int addressID,
		            DTOAddress dto);

		Task Delete(int addressID);

		Task<DTOAddress> Get(int addressID);

		Task<List<DTOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);
		Task<List<DTOAddress>> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>5df45773d847460311ed8366284fa241</Hash>
</Codenesium>*/