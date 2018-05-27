using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALPersonCreditCardMapper
	{
		void MapDTOToEF(
			int businessEntityID,
			DTOPersonCreditCard dto,
			PersonCreditCard efPersonCreditCard);

		DTOPersonCreditCard MapEFToDTO(
			PersonCreditCard efPersonCreditCard);
	}
}

/*<Codenesium>
    <Hash>d376537d3feb654db4333b213efabc46</Hash>
</Codenesium>*/