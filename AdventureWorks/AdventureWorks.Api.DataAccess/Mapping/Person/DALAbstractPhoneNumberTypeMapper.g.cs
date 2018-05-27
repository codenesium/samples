using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDALPhoneNumberTypeMapper
	{
		public virtual void MapDTOToEF(
			int phoneNumberTypeID,
			DTOPhoneNumberType dto,
			PhoneNumberType efPhoneNumberType)
		{
			efPhoneNumberType.SetProperties(
				phoneNumberTypeID,
				dto.ModifiedDate,
				dto.Name);
		}

		public virtual DTOPhoneNumberType MapEFToDTO(
			PhoneNumberType ef)
		{
			if (ef == null)
			{
				return null;
			}

			var dto = new DTOPhoneNumberType();

			dto.SetProperties(
				ef.PhoneNumberTypeID,
				ef.ModifiedDate,
				ef.Name);
			return dto;
		}
	}
}

/*<Codenesium>
    <Hash>2350b6eb4f3e064027207ad991d2c4b8</Hash>
</Codenesium>*/