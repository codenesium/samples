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

		POCOAddress Get(int addressID);

		List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOAddress GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);

		List<POCOAddress> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>24918fd98b5f818c41c027197ef30dfb</Hash>
</Codenesium>*/