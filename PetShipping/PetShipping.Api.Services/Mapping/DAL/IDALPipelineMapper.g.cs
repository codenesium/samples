using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>1ad680444914844fea43877efedc03f4</Hash>
</Codenesium>*/