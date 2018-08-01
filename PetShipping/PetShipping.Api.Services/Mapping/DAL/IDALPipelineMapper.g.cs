using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineMapper
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
    <Hash>bfc9b5536f60d6123aa4c3a37781a559</Hash>
</Codenesium>*/