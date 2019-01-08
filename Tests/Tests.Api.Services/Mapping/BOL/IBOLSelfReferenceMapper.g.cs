using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IBOLSelfReferenceMapper
	{
		BOSelfReference MapModelToBO(
			int id,
			ApiSelfReferenceServerRequestModel model);

		ApiSelfReferenceServerResponseModel MapBOToModel(
			BOSelfReference boSelfReference);

		List<ApiSelfReferenceServerResponseModel> MapBOToModel(
			List<BOSelfReference> items);
	}
}

/*<Codenesium>
    <Hash>31239f9fbee51ed23ba8650ad0587272</Hash>
</Codenesium>*/