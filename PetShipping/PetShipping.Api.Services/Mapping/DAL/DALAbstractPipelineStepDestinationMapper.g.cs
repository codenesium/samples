using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineStepDestinationMapper
	{
		public virtual PipelineStepDestination MapBOToEF(
			BOPipelineStepDestination bo)
		{
			PipelineStepDestination efPipelineStepDestination = new PipelineStepDestination();
			efPipelineStepDestination.SetProperties(
				bo.DestinationId,
				bo.Id,
				bo.PipelineStepId);
			return efPipelineStepDestination;
		}

		public virtual BOPipelineStepDestination MapEFToBO(
			PipelineStepDestination ef)
		{
			var bo = new BOPipelineStepDestination();

			bo.SetProperties(
				ef.Id,
				ef.DestinationId,
				ef.PipelineStepId);
			return bo;
		}

		public virtual List<BOPipelineStepDestination> MapEFToBO(
			List<PipelineStepDestination> records)
		{
			List<BOPipelineStepDestination> response = new List<BOPipelineStepDestination>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>188e63d0706d4347e2b7ec4766edbf22</Hash>
</Codenesium>*/