using System;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.DataAccess
{
	public abstract class AbstractDALFileTypeMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOFileType dto,
			FileType efFileType)
		{
			efFileType.SetProperties(
				id,
				dto.Name);
		}

		public virtual DTOFileType MapEFToDTO(
			FileType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOFileType();

			dto.SetProperties(
				ef.Id,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>bea2d038c014950b8ad6db53bbb725a6</Hash>
</Codenesium>*/