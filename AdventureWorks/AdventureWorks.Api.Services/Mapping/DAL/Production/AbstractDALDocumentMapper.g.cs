using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDocumentMapper
	{
		public virtual Document MapModelToBO(
			Guid rowguid,
			ApiDocumentServerRequestModel model
			)
		{
			Document item = new Document();
			item.SetProperties(
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
			return item;
		}

		public virtual ApiDocumentServerResponseModel MapBOToModel(
			Document item)
		{
			var model = new ApiDocumentServerResponseModel();

			model.SetProperties(item.Rowguid, item.ChangeNumber, item.Document1, item.DocumentLevel, item.DocumentSummary, item.FileExtension, item.FileName, item.FolderFlag, item.ModifiedDate, item.Owner, item.Revision, item.Status, item.Title);

			return model;
		}

		public virtual List<ApiDocumentServerResponseModel> MapBOToModel(
			List<Document> items)
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
    <Hash>a2d8cfe2fc001d9c5ef4b1b8acae2653</Hash>
</Codenesium>*/