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
    <Hash>d780b270b13ffab186ca5b82b899d1fb</Hash>
</Codenesium>*/