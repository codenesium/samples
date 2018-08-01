using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public interface IBOLSelfReferenceMapper
	{
		BOSelfReference MapModelToBO(
			int id,
			ApiSelfReferenceRequestModel model);

		ApiSelfReferenceResponseModel MapBOToModel(
			BOSelfReference boSelfReference);

		List<ApiSelfReferenceResponseModel> MapBOToModel(
			List<BOSelfReference> items);
	}
}

/*<Codenesium>
    <Hash>22f1b04e8dcd16cac2a1fe264d106b79</Hash>
</Codenesium>*/