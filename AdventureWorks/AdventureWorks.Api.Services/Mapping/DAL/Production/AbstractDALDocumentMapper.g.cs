using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDocumentMapper
	{
		public virtual Document MapModelToEntity(
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

		public virtual ApiDocumentServerResponseModel MapEntityToModel(
			Document item)
		{
			var model = new ApiDocumentServerResponseModel();

			model.SetProperties(item.Rowguid,
			                    item.ChangeNumber,
			                    item.Document1,
			                    item.DocumentLevel,
			                    item.DocumentSummary,
			                    item.FileExtension,
			                    item.FileName,
			                    item.FolderFlag,
			                    item.ModifiedDate,
			                    item.Owner,
			                    item.Revision,
			                    item.Status,
			                    item.Title);

			return model;
		}

		public virtual List<ApiDocumentServerResponseModel> MapEntityToModel(
			List<Document> items)
		{
			List<ApiDocumentServerResponseModel> response = new List<ApiDocumentServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c2788cdd22bd924c7dbfa4fa7f16c7de</Hash>
</Codenesium>*/