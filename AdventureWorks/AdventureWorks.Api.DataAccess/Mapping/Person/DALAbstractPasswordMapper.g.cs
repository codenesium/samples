using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPasswordMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOPassword dto,
			Password efPassword)
		{
			efPassword.SetProperties(
				businessEntityID,
				dto.ModifiedDate,
				dto.PasswordHash,
				dto.PasswordSalt,
				dto.Rowguid);
		}

		public virtual DTOPassword MapEFToDTO(
			Password ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPassword();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PasswordHash,
				ef.PasswordSalt,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>260176c5de7a1a913697605f4bb83688</Hash>
</Codenesium>*/