using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepStatuMapper
	{
		PipelineStepStatu MapBOToEF(
			BOPipelineStepStatu bo);

		BOPipelineStepStatu MapEFToBO(
			PipelineStepStatu efPipelineStepStatu);

		List<BOPipelineStepStatu> MapEFToBO(
			List<PipelineStepStatu> records);
	}
}

/*<Codenesium>
    <Hash>44d08eed74dbc9a2cb1cffb9c92bec05</Hash>
</Codenesium>*/