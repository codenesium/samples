using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALCurrencyMapper
	{
		void MapDTOToEF(
			string currencyCode,
			DTOCurrency dto,
			Currency efCurrency);

		DTOCurrency MapEFToDTO(
			Currency efCurrency);
	}
}

/*<Codenesium>
    <Hash>8520e9c8d54d74d202f9ca7c1f033288</Hash>
</Codenesium>*/