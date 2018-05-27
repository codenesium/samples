using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALContactTypeMapper
	{
		public virtual void MapDTOToEF(
			int contactTypeID,
			DTOContactType dto,
			ContactType efContactType)
		{
			efContactType.SetProperties(
				contactTypeID,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOContactType MapEFToDTO(
			ContactType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOContactType();

			dto.SetProperties(
				ef.ContactTypeID,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>81660d176219764346a58697af9e6b6b</Hash>
</Codenesium>*/