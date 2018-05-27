using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCreditCardMapper
	{
		void MapDTOToEF(
			int creditCardID,
			DTOCreditCard dto,
			CreditCard efCreditCard);

		DTOCreditCard MapEFToDTO(
			CreditCard efCreditCard);
	}
}

/*<Codenesium>
    <Hash>1d6c427e6bba4977a8dbf3b1077c28ea</Hash>
</Codenesium>*/