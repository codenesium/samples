using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IDALSelfReferenceMapper
	{
		SelfReference MapModelToEntity(
			int id,
			ApiSelfReferenceServerRequestModel model);

		ApiSelfReferenceServerResponseModel MapEntityToModel(
			SelfReference item);

		List<ApiSelfReferenceServerResponseModel> MapEntityToModel(
			List<SelfReference> items);
	}
}

/*<Codenesium>
    <Hash>0a5b092c293d25574ed8e867697890d6</Hash>
</Codenesium>*/