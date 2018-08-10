using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLDocumentMapper
	{
		BODocument MapModelToBO(
			Guid rowguid,
			ApiDocumentRequestModel model);

		ApiDocumentResponseModel MapBOToModel(
			BODocument boDocument);

		List<ApiDocumentResponseModel> MapBOToModel(
			List<BODocument> items);
	}
}

/*<Codenesium>
    <Hash>f0e697196ce51371780e322e61e6f829</Hash>
</Codenesium>*/