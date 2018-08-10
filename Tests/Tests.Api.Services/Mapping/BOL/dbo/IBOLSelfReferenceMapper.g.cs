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
			ApiSelfReferenceRequestModel model);

		ApiSelfReferenceResponseModel MapBOToModel(
			BOSelfReference boSelfReference);

		List<ApiSelfReferenceResponseModel> MapBOToModel(
			List<BOSelfReference> items);
	}
}

/*<Codenesium>
    <Hash>1475ec67d40222d57a243234477f315c</Hash>
</Codenesium>*/