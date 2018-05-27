using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALBusinessEntityContactMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntityContact dto,
			BusinessEntityContact efBusinessEntityContact)
		{
			efBusinessEntityContact.SetProperties(
				businessEntityID,
				dto.ContactTypeID,
				dto.ModifiedDate,
				dto.PersonID,
				dto.Rowguid);
		}

		public virtual DTOBusinessEntityContact MapEFToDTO(
			BusinessEntityContact ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBusinessEntityContact();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ContactTypeID,
				ef.ModifiedDate,
				ef.PersonID,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>458f9ee3bc88c0efcaffa184bd1ee8c4</Hash>
</Codenesium>*/