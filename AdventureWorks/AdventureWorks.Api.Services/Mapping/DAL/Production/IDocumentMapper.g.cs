using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDocumentMapper
	{
		Document MapModelToBO(
			Guid rowguid,
			ApiDocumentServerRequestModel model);

		ApiDocumentServerResponseModel MapBOToModel(
			Document item);

		List<ApiDocumentServerResponseModel> MapBOToModel(
			List<Document> items);
	}
}

/*<Codenesium>
    <Hash>5eded61f25b0d7f640d41630d376185f</Hash>
</Codenesium>*/