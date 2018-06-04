using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLProductDocumentMapper
	{
		BOProductDocument MapModelToBO(
			int productID,
			ApiProductDocumentRequestModel model);

		ApiProductDocumentResponseModel MapBOToModel(
			BOProductDocument boProductDocument);

		List<ApiProductDocumentResponseModel> MapBOToModel(
			List<BOProductDocument> bos);
	}
}

/*<Codenesium>
    <Hash>7cb8e0056f56b6de54c2c7248df4e24f</Hash>
</Codenesium>*/