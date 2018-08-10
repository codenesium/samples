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
    <Hash>ea102ca295af7378821e329f235318c3</Hash>
</Codenesium>*/