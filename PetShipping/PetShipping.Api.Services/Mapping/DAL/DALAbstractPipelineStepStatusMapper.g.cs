using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepStatusMapper
	{
		public virtual PipelineStepStatus MapBOToEF(
			BOPipelineStepStatus bo)
		{
			PipelineStepStatus efPipelineStepStatus = new PipelineStepStatus ();

			efPipelineStepStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStepStatus;
		}

		public virtual BOPipelineStepStatus MapEFToBO(
			PipelineStepStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPipelineStepStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPipelineStepStatus> MapEFToBO(
			List<PipelineStepStatus> records)
		{
			List<BOPipelineStepStatus> response = new List<BOPipelineStepStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2e9d92263b80ae5ed5a7d7d7e6bb9815</Hash>
</Codenesium>*/