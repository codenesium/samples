using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALHandlerPipelineStepMapper
	{
		public virtual HandlerPipelineStep MapBOToEF(
			BOHandlerPipelineStep bo)
		{
			HandlerPipelineStep efHandlerPipelineStep = new HandlerPipelineStep ();

			efHandlerPipelineStep.SetProperties(
				bo.HandlerId,
				bo.Id,
				bo.PipelineStepId);
			return efHandlerPipelineStep;
		}

		public virtual BOHandlerPipelineStep MapEFToBO(
			HandlerPipelineStep ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOHandlerPipelineStep();

			bo.SetProperties(
				ef.Id,
				ef.HandlerId,
				ef.PipelineStepId);
			return bo;
		}

		public virtual List<BOHandlerPipelineStep> MapEFToBO(
			List<HandlerPipelineStep> records)
		{
			List<BOHandlerPipelineStep> response = new List<BOHandlerPipelineStep>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2b212a89fded27a11f7993159b1974b2</Hash>
</Codenesium>*/