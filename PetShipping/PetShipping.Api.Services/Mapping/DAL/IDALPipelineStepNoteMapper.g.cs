using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALPipelineStepNoteMapper
	{
		PipelineStepNote MapBOToEF(
			BOPipelineStepNote bo);

		BOPipelineStepNote MapEFToBO(
			PipelineStepNote efPipelineStepNote);

		List<BOPipelineStepNote> MapEFToBO(
			List<PipelineStepNote> records);
	}
}

/*<Codenesium>
    <Hash>65593c41dcc604308e469b37a9989eed</Hash>
</Codenesium>*/