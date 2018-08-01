using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLDocumentMapper
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
    <Hash>d01a25883546896fbcd0278d80b47cde</Hash>
</Codenesium>*/