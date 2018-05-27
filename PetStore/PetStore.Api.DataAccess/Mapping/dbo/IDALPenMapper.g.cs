using System;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
namespace PetStoreNS.Api.DataAccess
{
	public interface IDALPenMapper
	{
		void MapDTOToEF(
			int id,
			DTOPen dto,
			Pen efPen);

		DTOPen MapEFToDTO(
			Pen efPen);
	}
}

/*<Codenesium>
    <Hash>0b80f280ccc35212599791d28ad40490</Hash>
</Codenesium>*/