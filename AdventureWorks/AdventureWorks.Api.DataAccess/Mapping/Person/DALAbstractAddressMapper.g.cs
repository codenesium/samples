using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALAddressMapper
	{
		public virtual void MapDTOToEF(
			int addressID,
			DTOAddress dto,
			Address efAddress)
		{
			efAddress.SetProperties(
				addressID,
				dto.AddressLine1,
				dto.AddressLine2,
				dto.City,
				dto.ModifiedDate,
				dto.PostalCode,
				dto.Rowguid,
				dto.StateProvinceID);
		}

		public virtual DTOAddress MapEFToDTO(
			Address ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAddress();

			dto.SetProperties(
				ef.AddressID,
				ef.AddressLine1,
				ef.AddressLine2,
				ef.City,
				ef.ModifiedDate,
				ef.PostalCode,
				ef.Rowguid,
				ef.StateProvinceID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>c6c029b8db7d6543a98ee3676515642d</Hash>
</Codenesium>*/