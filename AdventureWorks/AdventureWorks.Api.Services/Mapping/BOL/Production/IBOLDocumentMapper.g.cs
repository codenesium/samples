using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLDocumentMapper
	{
		BODocument MapModelToBO(
			Guid documentNode,
			ApiDocumentRequestModel model);

		ApiDocumentResponseModel MapBOToModel(
			BODocument boDocument);

		List<ApiDocumentResponseModel> MapBOToModel(
			List<BODocument> items);
	}
}

/*<Codenesium>
    <Hash>5be57abf9984ca774cbbccdeefa3f596</Hash>
</Codenesium>*/