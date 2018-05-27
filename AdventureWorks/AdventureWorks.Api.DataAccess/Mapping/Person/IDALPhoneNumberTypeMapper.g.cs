using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPhoneNumberTypeMapper
	{
		void MapDTOToEF(
			int phoneNumberTypeID,
			DTOPhoneNumberType dto,
			PhoneNumberType efPhoneNumberType);

		DTOPhoneNumberType MapEFToDTO(
			PhoneNumberType efPhoneNumberType);
	}
}

/*<Codenesium>
    <Hash>0f817a05d00fe840160e9ee6c56d89be</Hash>
</Codenesium>*/