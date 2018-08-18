using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public abstract class DALAbstractPipelineMapper
	{
		public virtual Pipeline MapBOToEF(
			BOPipeline bo)
		{
			Pipeline efPipeline = new Pipeline();
			efPipeline.SetProperties(
				bo.Id,
				bo.PipelineStatusId,
				bo.SaleId);
			return efPipeline;
		}

		public virtual BOPipeline MapEFToBO(
			Pipeline ef)
		{
			var bo = new BOPipeline();

			bo.SetProperties(
				ef.Id,
				ef.PipelineStatusId,
				ef.SaleId);
			return bo;
		}

		public virtual List<BOPipeline> MapEFToBO(
			List<Pipeline> records)
		{
			List<BOPipeline> response = new List<BOPipeline>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b1927fe7b098b1faaa50bf73f7f9ebe0</Hash>
</Codenesium>*/