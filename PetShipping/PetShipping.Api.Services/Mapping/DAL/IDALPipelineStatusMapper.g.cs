using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStatusMapper
	{
		PipelineStatus MapBOToEF(
			BOPipelineStatus bo);

		BOPipelineStatus MapEFToBO(
			PipelineStatus efPipelineStatus);

		List<BOPipelineStatus> MapEFToBO(
			List<PipelineStatus> records);
	}
}

/*<Codenesium>
    <Hash>d5cb5df8f558c2615c41aa6d065b3692</Hash>
</Codenesium>*/