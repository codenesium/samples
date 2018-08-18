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
    <Hash>907ee26a4ffff18dea7bf442a09edaa6</Hash>
</Codenesium>*/