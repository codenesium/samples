using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPersonPhoneMapper
	{
		public virtual void MapDTOToEF(
			int businessEntityID,
			DTOPersonPhone dto,
			PersonPhone efPersonPhone)
		{
			efPersonPhone.SetProperties(
				businessEntityID,
				dto.ModifiedDate,
				dto.PhoneNumber,
				dto.PhoneNumberTypeID);
		}

		public virtual DTOPersonPhone MapEFToDTO(
			PersonPhone ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPersonPhone();

			dto.SetProperties(
				ef.BusinessEntityID,
				ef.ModifiedDate,
				ef.PhoneNumber,
				ef.PhoneNumberTypeID);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>2175dd1bffe11173ecb92696a74fafe1</Hash>
</Codenesium>*/