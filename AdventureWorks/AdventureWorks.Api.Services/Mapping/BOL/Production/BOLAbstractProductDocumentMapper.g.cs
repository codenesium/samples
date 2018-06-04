using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractProductDocumentMapper
	{
		public virtual BOProductDocument MapModelToBO(
			int productID,
			ApiProductDocumentRequestModel model
			)
		{
			BOProductDocument BOProductDocument = new BOProductDocument();

			BOProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
			return BOProductDocument;
		}

		public virtual ApiProductDocumentResponseModel MapBOToModel(
			BOProductDocument BOProductDocument)
		{
			if (BOProductDocument == null)
			{
				return null;
			}

			var model = new ApiProductDocumentResponseModel();

			model.SetProperties(BOProductDocument.DocumentNode, BOProductDocument.ModifiedDate, BOProductDocument.ProductID);

			return model;
		}

		public virtual List<ApiProductDocumentResponseModel> MapBOToModel(
			List<BOProductDocument> BOs)
		{
			List<ApiProductDocumentResponseModel> response = new List<ApiProductDocumentResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>24a0519a4911a3341ab0a2ed8904c987</Hash>
</Codenesium>*/