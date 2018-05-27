using System;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
namespace PetShippingNS.Api.DataAccess
{
	public interface IDALHandlerPipelineStepMapper
	{
		void MapDTOToEF(
			int id,
			DTOHandlerPipelineStep dto,
			HandlerPipelineStep efHandlerPipelineStep);

		DTOHandlerPipelineStep MapEFToDTO(
			HandlerPipelineStep efHandlerPipelineStep);
	}
}

/*<Codenesium>
    <Hash>0750558bfbb611d5bc7a088c7fb9d25a</Hash>
</Codenesium>*/