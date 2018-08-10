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
    <Hash>c81d7aef0c9ff18e51964149562ca61e</Hash>
</Codenesium>*/