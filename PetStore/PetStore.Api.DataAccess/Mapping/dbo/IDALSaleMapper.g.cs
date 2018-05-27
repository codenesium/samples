using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IDALSaleMapper
	{
		void MapDTOToEF(
			int id,
			DTOSale dto,
			Sale efSale);

		DTOSale MapEFToDTO(
			Sale efSale);
	}
}

/*<Codenesium>
    <Hash>6eff8d2e6dd179300d09278cddc0d7b3</Hash>
</Codenesium>*/