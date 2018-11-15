using Microsoft.EntityFrameworkCore;
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
    <Hash>b3766d6450a9116c42e8b5059e742384</Hash>
</Codenesium>*/