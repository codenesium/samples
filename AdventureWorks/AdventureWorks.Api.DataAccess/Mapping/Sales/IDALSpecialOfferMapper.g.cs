using System;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDALSpecialOfferMapper
	{
		void MapDTOToEF(
			int specialOfferID,
			DTOSpecialOffer dto,
			SpecialOffer efSpecialOffer);

		DTOSpecialOffer MapEFToDTO(
			SpecialOffer efSpecialOffer);
	}
}

/*<Codenesium>
    <Hash>a26670f34f630b9d5f2de2a809689daa</Hash>
</Codenesium>*/