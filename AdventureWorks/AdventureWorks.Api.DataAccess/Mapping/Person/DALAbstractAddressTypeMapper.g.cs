using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALAddressTypeMapper
	{
		public virtual void MapDTOToEF(
			int addressTypeID,
			DTOAddressType dto,
			AddressType efAddressType)
		{
			efAddressType.SetProperties(
				addressTypeID,
				dto.ModifiedDate,
				dto.Name,
				dto.Rowguid);
		}

		public virtual DTOAddressType MapEFToDTO(
			AddressType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOAddressType();

			dto.SetProperties(
				ef.AddressTypeID,
				ef.ModifiedDate,
				ef.Name,
				ef.Rowguid);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>0c4d219a4384fedfed82862eecbf8335</Hash>
</Codenesium>*/