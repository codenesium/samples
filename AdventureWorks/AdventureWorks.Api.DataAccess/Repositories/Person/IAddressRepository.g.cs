using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressRepository
	{
		POCOAddress Create(ApiAddressModel model);

		void Update(int addressID,
		            ApiAddressModel model);

		void Delete(int addressID);

		POCOAddress Get(int addressID);

		List<POCOAddress> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOAddress GetAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1,string addressLine2,string city,int stateProvinceID,string postalCode);

		List<POCOAddress> GetStateProvinceID(int stateProvinceID);
	}
}

/*<Codenesium>
    <Hash>b414faa3ad37ea7931e49637cc688570</Hash>
</Codenesium>*/