using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineStepStatusMapper
	{
		public virtual PipelineStepStatus MapBOToEF(
			BOPipelineStepStatus bo)
		{
			PipelineStepStatus efPipelineStepStatus = new PipelineStepStatus();
			efPipelineStepStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStepStatus;
		}

		public virtual BOPipelineStepStatus MapEFToBO(
			PipelineStepStatus ef)
		{
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
    <Hash>60602b49ba928f49c568209e32b23985</Hash>
</Codenesium>*/