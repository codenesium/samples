using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2ae02cb27a14576d287f5ee0f019285c</Hash>
</Codenesium>*/