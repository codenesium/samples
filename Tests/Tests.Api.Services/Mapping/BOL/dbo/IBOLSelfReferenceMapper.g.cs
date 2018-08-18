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
    <Hash>cd0b3140db79122c697fde29ee5b545d</Hash>
</Codenesium>*/