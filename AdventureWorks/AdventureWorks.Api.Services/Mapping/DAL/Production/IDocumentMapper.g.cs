using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALDocumentMapper
	{
		Document MapModelToEntity(
			Guid rowguid,
			ApiDocumentServerRequestModel model);

		ApiDocumentServerResponseModel MapEntityToModel(
			Document item);

		List<ApiDocumentServerResponseModel> MapEntityToModel(
			List<Document> items);
	}
}

/*<Codenesium>
    <Hash>3d0b52c050eff6d6bc345973aff46e18</Hash>
</Codenesium>*/