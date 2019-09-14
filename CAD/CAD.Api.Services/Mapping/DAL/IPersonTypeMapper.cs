using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace CADNS.Api.Services
{
	public partial interface IDALPersonTypeMapper
	{
		PersonType MapModelToEntity(
			int id,
			ApiPersonTypeServerRequestModel model);

		ApiPersonTypeServerResponseModel MapEntityToModel(
			PersonType item);

		List<ApiPersonTypeServerResponseModel> MapEntityToModel(
			List<PersonType> items);
	}
}

/*<Codenesium>
    <Hash>7e8cfda628377546c0fb5d8dc9d2f246</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/