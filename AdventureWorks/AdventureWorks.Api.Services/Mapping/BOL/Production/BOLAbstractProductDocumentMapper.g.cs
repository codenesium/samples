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
			BOProductDocument boProductDocument = new BOProductDocument();

			boProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
			return boProductDocument;
		}

		public virtual ApiProductDocumentResponseModel MapBOToModel(
			BOProductDocument boProductDocument)
		{
			var model = new ApiProductDocumentResponseModel();

			model.SetProperties(boProductDocument.DocumentNode, boProductDocument.ModifiedDate, boProductDocument.ProductID);

			return model;
		}

		public virtual List<ApiProductDocumentResponseModel> MapBOToModel(
			List<BOProductDocument> items)
		{
			List<ApiProductDocumentResponseModel> response = new List<ApiProductDocumentResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>56411a1f33272c2cb2a53134f2195cc2</Hash>
</Codenesium>*/