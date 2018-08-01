using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLEventRelatedDocumentMapper
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
    <Hash>52760ad76c09e8df949ce49d59337f0b</Hash>
</Codenesium>*/