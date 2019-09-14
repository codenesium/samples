using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALVPersonMapper
	{
		VPerson MapModelToEntity(
			int personId,
			ApiVPersonServerRequestModel model);

		ApiVPersonServerResponseModel MapEntityToModel(
			VPerson item);

		List<ApiVPersonServerResponseModel> MapEntityToModel(
			List<VPerson> items);
	}
}

/*<Codenesium>
    <Hash>397021e264217500b44f37604e9412c8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/