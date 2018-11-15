using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Client
{
	public partial interface IApiSchemaAPersonModelMapper
	{
		ApiSchemaAPersonClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSchemaAPersonClientRequestModel request);

		ApiSchemaAPersonClientRequestModel MapClientResponseToRequest(
			ApiSchemaAPersonClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2b1d08f90bc2d8b9c1479dbe96ffda6c</Hash>
</Codenesium>*/