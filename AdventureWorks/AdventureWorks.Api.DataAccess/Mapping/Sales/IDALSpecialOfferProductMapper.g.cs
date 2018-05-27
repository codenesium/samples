using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSpecialOfferProductMapper
	{
		void MapDTOToEF(
			int specialOfferID,
			DTOSpecialOfferProduct dto,
			SpecialOfferProduct efSpecialOfferProduct);

		DTOSpecialOfferProduct MapEFToDTO(
			SpecialOfferProduct efSpecialOfferProduct);
	}
}

/*<Codenesium>
    <Hash>0e67c99a89f35925d32f57b8a6ecdc3f</Hash>
</Codenesium>*/