using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStepNoteMapper
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
    <Hash>08dd49212ee5f5ba751559c8d220ade7</Hash>
</Codenesium>*/