using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStepDestinationMapper
	{
		public virtual PipelineStepDestination MapBOToEF(
			BOPipelineStepDestination bo)
		{
			PipelineStepDestination efPipelineStepDestination = new PipelineStepDestination ();

			efPipelineStepDestination.SetProperties(
				bo.DestinationId,
				bo.Id,
				bo.PipelineStepId);
			return efPipelineStepDestination;
		}

		public virtual BOPipelineStepDestination MapEFToBO(
			PipelineStepDestination ef)
		{
			if (ef == null)
			{
				return null;
			}

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
    <Hash>4f43787053ee46de12638c0de1948b45</Hash>
</Codenesium>*/