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
			List<BODocument> bos);
	}
}

/*<Codenesium>
    <Hash>1c9c7ce9456a53653e94046a86009d56</Hash>
</Codenesium>*/