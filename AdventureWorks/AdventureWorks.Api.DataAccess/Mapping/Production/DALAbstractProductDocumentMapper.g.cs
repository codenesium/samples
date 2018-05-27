using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALProductDocumentMapper
	{
		public virtual void MapDTOToEF(
			int productID,
			DTOProductDocument dto,
			ProductDocument efProductDocument)
		{
			efProductDocument.SetProperties(
				productID,
				dto.DocumentNode,
				dto.ModifiedDate);
		}

		public virtual DTOProductDocument MapEFToDTO(
			ProductDocument ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOProductDocument();

			dto.SetProperties(
				ef.ProductID,
				ef.DocumentNode,
				ef.ModifiedDate);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>1c7aba1ffb052e4f864bf1358838b4a4</Hash>
</Codenesium>*/