using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALPipelineStatusMapper
	{
		void MapDTOToEF(
			int id,
			DTOPipelineStatus dto,
			PipelineStatus efPipelineStatus);

		DTOPipelineStatus MapEFToDTO(
			PipelineStatus efPipelineStatus);
	}
}

/*<Codenesium>
    <Hash>8f748803c1d4e2c2cc7c02e7894d4544</Hash>
</Codenesium>*/