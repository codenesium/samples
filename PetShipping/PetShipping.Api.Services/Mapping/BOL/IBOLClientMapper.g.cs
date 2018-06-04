using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IBOLClientMapper
	{
		BOClient MapModelToBO(
			int id,
			ApiClientRequestModel model);

		ApiClientResponseModel MapBOToModel(
			BOClient boClient);

		List<ApiClientResponseModel> MapBOToModel(
			List<BOClient> bos);
	}
}

/*<Codenesium>
    <Hash>5385d10fe1b452303270bec33c6efc50</Hash>
</Codenesium>*/