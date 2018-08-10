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
    <Hash>9da01c746c8057ca94d9c6449c64da3e</Hash>
</Codenesium>*/