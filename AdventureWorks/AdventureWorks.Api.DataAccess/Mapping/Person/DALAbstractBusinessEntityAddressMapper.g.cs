using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALBusinessEntityAddressMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOBusinessEntityAddress dto,
			BusinessEntityAddress efBusinessEntityAddress)
		{
			efBusinessEntityAddress.SetProperties(
				businessEntityID,
				dto.AddressID,
				dto.AddressTypeID,
				dto.ModifiedDate,
				dto.Rowguid);
		}

		public virtual DTOBusinessEntityAddress MapEFToDTO(
			BusinessEntityAddress ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOBusinessEntityAddress();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.AddressID,
				ef.AddressTypeID,
				ef.ModifiedDate,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>03551ab0d85d77ec64a24d316db3355a</Hash>
</Codenesium>*/