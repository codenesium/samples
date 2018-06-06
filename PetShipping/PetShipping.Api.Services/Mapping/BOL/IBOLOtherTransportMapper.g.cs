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
			List<BOOtherTransport> items);
	}
}

/*<Codenesium>
    <Hash>ffa3876387686ca8f35ba97768f665ca</Hash>
</Codenesium>*/