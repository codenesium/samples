using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLDocumentMapper
	{
		public virtual DTODocument MapModelToDTO(
			Guid documentNode,
			ApiDocumentRequestModel model
			)
		{
			DTODocument dtoDocument = new DTODocument();

			dtoDocument.SetProperties(
				documentNode,
				model.ChangeNumber,
				model.Document1,
				model.DocumentLevel,
				model.DocumentSummary,
				model.FileExtension,
				model.FileName,
				model.FolderFlag,
				model.ModifiedDate,
				model.Owner,
				model.Revision,
				model.Rowguid,
				model.Status,
				model.Title);
			return dtoDocument;
		}

		public virtual ApiDocumentResponseModel MapDTOToModel(
			DTODocument dtoDocument)
		{
			if (dtoDocument == null)
			{
				return null;
			}

			var model = new ApiDocumentResponseModel();

			model.SetProperties(dtoDocument.ChangeNumber, dtoDocument.Document1, dtoDocument.DocumentLevel, dtoDocument.DocumentNode, dtoDocument.DocumentSummary, dtoDocument.FileExtension, dtoDocument.FileName, dtoDocument.FolderFlag, dtoDocument.ModifiedDate, dtoDocument.Owner, dtoDocument.Revision, dtoDocument.Rowguid, dtoDocument.Status, dtoDocument.Title);

			return model;
		}

		public virtual List<ApiDocumentResponseModel> MapDTOToModel(
			List<DTODocument> dtos)
		{
			List<ApiDocumentResponseModel> response = new List<ApiDocumentResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3253db6e6daeb54b921c5f08377ae22a</Hash>
</Codenesium>*/