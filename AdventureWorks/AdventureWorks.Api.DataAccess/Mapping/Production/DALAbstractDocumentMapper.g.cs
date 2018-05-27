using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALDocumentMapper
	{
		public virtual void MapDTOToEF(
			Guid documentNode,
			DTODocument dto,
			Document efDocument)
		{
			efDocument.SetProperties(
				documentNode,
				dto.ChangeNumber,
				dto.Document1,
				dto.DocumentLevel,
				dto.DocumentSummary,
				dto.FileExtension,
				dto.FileName,
				dto.FolderFlag,
				dto.ModifiedDate,
				dto.Owner,
				dto.Revision,
				dto.Rowguid,
				dto.Status,
				dto.Title);
		}

		public virtual DTODocument MapEFToDTO(
			Document ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTODocument();

			dto.SetProperties(
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
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>9e55202e3cbc0efa8d172b3fe99c896c</Hash>
</Codenesium>*/