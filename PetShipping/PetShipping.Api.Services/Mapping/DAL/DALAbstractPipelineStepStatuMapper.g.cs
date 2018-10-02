using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineStepStatuMapper
	{
		public virtual PipelineStepStatu MapBOToEF(
			BOPipelineStepStatu bo)
		{
			PipelineStepStatu efPipelineStepStatu = new PipelineStepStatu();
			efPipelineStepStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStepStatu;
		}

		public virtual BOPipelineStepStatu MapEFToBO(
			PipelineStepStatu ef)
		{
			var bo = new BOPipelineStepStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPipelineStepStatu> MapEFToBO(
			List<PipelineStepStatu> records)
		{
			List<BOPipelineStepStatu> response = new List<BOPipelineStepStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ec51274904ec477812a9cf3eee4e5502</Hash>
</Codenesium>*/