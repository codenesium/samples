using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
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
    <Hash>f425b2a3a2fd63878ec92eb03a2e7c78</Hash>
</Codenesium>*/