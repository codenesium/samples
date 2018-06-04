using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLOtherTransportMapper
	{
		BOOtherTransport MapModelToBO(
			int id,
			ApiOtherTransportRequestModel model);

		ApiOtherTransportResponseModel MapBOToModel(
			BOOtherTransport boOtherTransport);

		List<ApiOtherTransportResponseModel> MapBOToModel(
			List<BOOtherTransport> bos);
	}
}

/*<Codenesium>
    <Hash>64abccd5bfeb8d9105791871263c4717</Hash>
</Codenesium>*/