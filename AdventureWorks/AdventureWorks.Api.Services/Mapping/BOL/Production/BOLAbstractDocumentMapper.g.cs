using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class BOLAbstractDocumentMapper
	{
		public virtual BODocument MapModelToBO(
			Guid documentNode,
			ApiDocumentRequestModel model
			)
		{
			BODocument BODocument = new BODocument();

			BODocument.SetProperties(
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
			return BODocument;
		}

		public virtual ApiDocumentResponseModel MapBOToModel(
			BODocument BODocument)
		{
			if (BODocument == null)
			{
				return null;
			}

			var model = new ApiDocumentResponseModel();

			model.SetProperties(BODocument.ChangeNumber, BODocument.Document1, BODocument.DocumentLevel, BODocument.DocumentNode, BODocument.DocumentSummary, BODocument.FileExtension, BODocument.FileName, BODocument.FolderFlag, BODocument.ModifiedDate, BODocument.Owner, BODocument.Revision, BODocument.Rowguid, BODocument.Status, BODocument.Title);

			return model;
		}

		public virtual List<ApiDocumentResponseModel> MapBOToModel(
			List<BODocument> BOs)
		{
			List<ApiDocumentResponseModel> response = new List<ApiDocumentResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>5db7f84eae99f06267df53e6199c09b6</Hash>
</Codenesium>*/