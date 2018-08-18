using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineMapper
	{
		Pipeline MapBOToEF(
			BOPipeline bo);

		BOPipeline MapEFToBO(
			Pipeline efPipeline);

		List<BOPipeline> MapEFToBO(
			List<Pipeline> records);
	}
}

/*<Codenesium>
    <Hash>ec7cea9c2ec0f483b128faf82c0553c8</Hash>
</Codenesium>*/