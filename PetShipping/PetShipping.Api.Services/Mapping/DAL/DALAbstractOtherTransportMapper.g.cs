using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDALOtherTransportMapper
	{
		public virtual OtherTransport MapBOToEF(
			BOOtherTransport bo)
		{
			OtherTransport efOtherTransport = new OtherTransport ();

			efOtherTransport.SetProperties(
				bo.HandlerId,
				bo.Id,
				bo.PipelineStepId);
			return efOtherTransport;
		}

		public virtual BOOtherTransport MapEFToBO(
			OtherTransport ef)
		{
			if (ef == null)
			{
				return null;
			}

			var bo = new BOOtherTransport();

			bo.SetProperties(
				ef.Id,
				ef.HandlerId,
				ef.PipelineStepId);
			return bo;
		}

		public virtual List<BOOtherTransport> MapEFToBO(
			List<OtherTransport> records)
		{
			List<BOOtherTransport> response = new List<BOOtherTransport>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a23c137c6d44a6f65ad9f2622c834e29</Hash>
</Codenesium>*/