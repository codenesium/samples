using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDocumentMapper
	{
		public virtual BODocument MapModelToBO(
			Guid rowguid,
			ApiDocumentServerRequestModel model
			)
		{
			BODocument boDocument = new BODocument();
			boDocument.SetProperties(
				rowguid,
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
				model.Status,
				model.Title);
			return boDocument;
		}

		public virtual ApiDocumentServerResponseModel MapBOToModel(
			BODocument boDocument)
		{
			var model = new ApiDocumentServerResponseModel();

			model.SetProperties(boDocument.Rowguid, boDocument.ChangeNumber, boDocument.Document1, boDocument.DocumentLevel, boDocument.DocumentSummary, boDocument.FileExtension, boDocument.FileName, boDocument.FolderFlag, boDocument.ModifiedDate, boDocument.Owner, boDocument.Revision, boDocument.Status, boDocument.Title);

			return model;
		}

		public virtual List<ApiDocumentServerResponseModel> MapBOToModel(
			List<BODocument> items)
		{
			List<ApiDocumentServerResponseModel> response = new List<ApiDocumentServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>3eff321fafb29a32fbee59b9790df192</Hash>
</Codenesium>*/