using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALPipelineStatusMapper
	{
		public virtual PipelineStatus MapBOToEF(
			BOPipelineStatus bo)
		{
			PipelineStatus efPipelineStatus = new PipelineStatus ();

			efPipelineStatus.SetProperties(
				bo.Id,
				bo.Name);
			return efPipelineStatus;
		}

		public virtual BOPipelineStatus MapEFToBO(
			PipelineStatus ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOPipelineStatus();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOPipelineStatus> MapEFToBO(
			List<PipelineStatus> records)
		{
			List<BOPipelineStatus> response = new List<BOPipelineStatus>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0aa71a5ab28ef08775539d4485255939</Hash>
</Codenesium>*/