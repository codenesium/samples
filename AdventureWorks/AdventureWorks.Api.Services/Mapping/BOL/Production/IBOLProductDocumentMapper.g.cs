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
			List<BOProductDocument> items);
	}
}

/*<Codenesium>
    <Hash>dbbe700389088e8af9ca399f54635b4e</Hash>
</Codenesium>*/