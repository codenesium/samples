using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCurrencyRateMapper
	{
		void MapDTOToEF(
			int currencyRateID,
			DTOCurrencyRate dto,
			CurrencyRate efCurrencyRate);

		DTOCurrencyRate MapEFToDTO(
			CurrencyRate efCurrencyRate);
	}
}

/*<Codenesium>
    <Hash>c7155cc1c89799f84f5c39f44ea2c68b</Hash>
</Codenesium>*/