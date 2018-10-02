using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineStatuMapper
	{
		public virtual PipelineStatu MapBOToEF(
			BOPipelineStatu bo)
		{
			PipelineStatu efPipelineStatu = new PipelineStatu();
			efPipelineStatu.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStatu;
		}

		public virtual BOPipelineStatu MapEFToBO(
			PipelineStatu ef)
		{
			var bo = new BOPipelineStatu();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPipelineStatu> MapEFToBO(
			List<PipelineStatu> records)
		{
			List<BOPipelineStatu> response = new List<BOPipelineStatu>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d9f49c2a82ea90ac971ef09ee0f70ad4</Hash>
</Codenesium>*/