using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLProductDocumentMapper
	{
		public virtual DTOProductDocument MapModelToDTO(
			int productID,
			ApiProductDocumentRequestModel model
			)
		{
			DTOProductDocument dtoProductDocument = new DTOProductDocument();

			dtoProductDocument.SetProperties(
				productID,
				model.DocumentNode,
				model.ModifiedDate);
			return dtoProductDocument;
		}

		public virtual ApiProductDocumentResponseModel MapDTOToModel(
			DTOProductDocument dtoProductDocument)
		{
			if (dtoProductDocument == null)
			{
				return null;
			}

			var model = new ApiProductDocumentResponseModel();

			model.SetProperties(dtoProductDocument.DocumentNode, dtoProductDocument.ModifiedDate, dtoProductDocument.ProductID);

			return model;
		}

		public virtual List<ApiProductDocumentResponseModel> MapDTOToModel(
			List<DTOProductDocument> dtos)
		{
			List<ApiProductDocumentResponseModel> response = new List<ApiProductDocumentResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>07e03a6229b5ba9e6d692159c8e8b48f</Hash>
</Codenesium>*/