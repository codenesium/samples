using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IBOLPipelineStatuMapper
	{
		BOPipelineStatu MapModelToBO(
			int id,
			ApiPipelineStatuServerRequestModel model);

		ApiPipelineStatuServerResponseModel MapBOToModel(
			BOPipelineStatu boPipelineStatu);

		List<ApiPipelineStatuServerResponseModel> MapBOToModel(
			List<BOPipelineStatu> items);
	}
}

/*<Codenesium>
    <Hash>0ede2ae4baca820f3752ab2a13d0ea65</Hash>
</Codenesium>*/