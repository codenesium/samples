using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStatusMapper
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
    <Hash>0d4a986d537e2c61eb0ecb0419fb4228</Hash>
</Codenesium>*/