using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALCountryMapper
	{
		void MapDTOToEF(
			int id,
			DTOCountry dto,
			Country efCountry);

		DTOCountry MapEFToDTO(
			Country efCountry);
	}
}

/*<Codenesium>
    <Hash>7948090f80d71e3b5866548b82b5800f</Hash>
</Codenesium>*/