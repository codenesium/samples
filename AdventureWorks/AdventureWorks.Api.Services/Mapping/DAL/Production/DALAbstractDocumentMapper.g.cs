using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractDALDocumentMapper
	{
		public virtual Document MapBOToEF(
			BODocument bo)
		{
			Document efDocument = new Document ();

			efDocument.SetProperties(
				bo.ChangeNumber,
				bo.Document1,
				bo.DocumentLevel,
				bo.DocumentNode,
				bo.DocumentSummary,
				bo.FileExtension,
				bo.FileName,
				bo.FolderFlag,
				bo.ModifiedDate,
				bo.Owner,
				bo.Revision,
				bo.Rowguid,
				bo.Status,
				bo.Title);
			return efDocument;
		}

		public virtual BODocument MapEFToBO(
			Document ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BODocument();

			bo.SetProperties(
				ef.DocumentNode,
				ef.ChangeNumber,
				ef.Document1,
				ef.DocumentLevel,
				ef.DocumentSummary,
				ef.FileExtension,
				ef.FileName,
				ef.FolderFlag,
				ef.ModifiedDate,
				ef.Owner,
				ef.Revision,
				ef.Rowguid,
				ef.Status,
				ef.Title);
			return bo;
		}

		public virtual List<BODocument> MapEFToBO(
			List<Document> records)
		{
			List<BODocument> response = new List<BODocument>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0378a0be867a3075099e03af27d11632</Hash>
</Codenesium>*/