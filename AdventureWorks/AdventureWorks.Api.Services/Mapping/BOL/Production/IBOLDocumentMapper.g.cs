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
			ApiDocumentServerRequestModel model);

		ApiDocumentServerResponseModel MapBOToModel(
			BODocument boDocument);

		List<ApiDocumentServerResponseModel> MapBOToModel(
			List<BODocument> items);
	}
}

/*<Codenesium>
    <Hash>b36d75c5196a7e9e1784c4da2598252d</Hash>
</Codenesium>*/