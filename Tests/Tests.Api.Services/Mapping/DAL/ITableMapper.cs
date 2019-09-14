using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALTableMapper
	{
		Table MapModelToEntity(
			int id,
			ApiTableServerRequestModel model);

		ApiTableServerResponseModel MapEntityToModel(
			Table item);

		List<ApiTableServerResponseModel> MapEntityToModel(
			List<Table> items);
	}
}

/*<Codenesium>
    <Hash>769aea09ecb8b856f8911b21ec8413a6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/