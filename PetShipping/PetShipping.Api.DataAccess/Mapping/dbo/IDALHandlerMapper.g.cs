using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALHandlerMapper
	{
		void MapDTOToEF(
			int id,
			DTOHandler dto,
			Handler efHandler);

		DTOHandler MapEFToDTO(
			Handler efHandler);
	}
}

/*<Codenesium>
    <Hash>0af6ca0a9489a31f1b08690102fdbacc</Hash>
</Codenesium>*/