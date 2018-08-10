using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLEventRelatedDocumentMapper
	{
		BOEventRelatedDocument MapModelToBO(
			int id,
			ApiEventRelatedDocumentRequestModel model);

		ApiEventRelatedDocumentResponseModel MapBOToModel(
			BOEventRelatedDocument boEventRelatedDocument);

		List<ApiEventRelatedDocumentResponseModel> MapBOToModel(
			List<BOEventRelatedDocument> items);
	}
}

/*<Codenesium>
    <Hash>b5cbe0e69fcdfa4f140a51b5e76e707e</Hash>
</Codenesium>*/