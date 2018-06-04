using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>79cbe807fc8918dc2fb6b32b4129d6e0</Hash>
</Codenesium>*/