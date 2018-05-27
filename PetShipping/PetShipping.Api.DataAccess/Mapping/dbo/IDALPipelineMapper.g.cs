using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipeline dto,
			Pipeline efPipeline);

		DTOPipeline MapEFToDTO(
			Pipeline efPipeline);
	}
}

/*<Codenesium>
    <Hash>bc3fd31c9a0688abf66aa67b60325e0d</Hash>
</Codenesium>*/