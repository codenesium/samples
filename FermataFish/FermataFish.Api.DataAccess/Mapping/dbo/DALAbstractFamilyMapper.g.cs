using System;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractDALFamilyMapper
	{
		public virtual void MapDTOToEF(
			int id,
			DTOFamily dto,
			Family efFamily)
		{
			efFamily.SetProperties(
				id,
				dto.Notes,
				dto.PcEmail,
				dto.PcFirstName,
				dto.PcLastName,
				dto.PcPhone,
				dto.StudioId);
		}

		public virtual DTOFamily MapEFToDTO(
			Family ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOFamily();

			dto.SetProperties(
				ef.Id,
				ef.Notes,
				ef.PcEmail,
				ef.PcFirstName,
				ef.PcLastName,
				ef.PcPhone,
				ef.StudioId);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>be6c7db840256a7c10a0c192da822d9f</Hash>
</Codenesium>*/