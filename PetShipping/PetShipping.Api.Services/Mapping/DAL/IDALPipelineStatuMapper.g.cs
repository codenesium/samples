using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALPipelineStatuMapper
	{
		PipelineStatu MapBOToEF(
			BOPipelineStatu bo);

		BOPipelineStatu MapEFToBO(
			PipelineStatu efPipelineStatu);

		List<BOPipelineStatu> MapEFToBO(
			List<PipelineStatu> records);
	}
}

/*<Codenesium>
    <Hash>b12cfa7b998c22d2f58bb3fa2e632b86</Hash>
</Codenesium>*/