using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAddress
	{
		Task<CreateResponse<POCOAddress>> Create(
			ApiAddressModel model);

		Task<ActionResponse> Update(int addressID,
		                            ApiAddressModel model);

		Task<ActionResponse> Delete(int addressID);

		Task<POCOAddress> Get(int addressID);

		Task<List<POCOAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOAddress> GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);
		Task<List<POCOAddress>> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>ac9799ab00299992d0dba84c58162c17</Hash>
</Codenesium>*/