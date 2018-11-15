using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractLinkMapper
	{
		public virtual Link MapBOToEF(
			BOLink bo)
		{
			Link efLink = new Link();
			efLink.SetProperties(
				bo.AssignedMachineId,
				bo.ChainId,
				bo.DateCompleted,
				bo.DateStarted,
				bo.DynamicParameter,
				bo.ExternalId,
				bo.Id,
				bo.LinkStatusId,
				bo.Name,
				bo.Order,
				bo.Response,
				bo.StaticParameter,
				bo.TimeoutInSecond);
			return efLink;
		}

		public virtual BOLink MapEFToBO(
			Link ef)
		{
			var bo = new BOLink();

			bo.SetProperties(
				ef.Id,
				ef.AssignedMachineId,
				ef.ChainId,
				ef.DateCompleted,
				ef.DateStarted,
				ef.DynamicParameter,
				ef.ExternalId,
				ef.LinkStatusId,
				ef.Name,
				ef.Order,
				ef.Response,
				ef.StaticParameter,
				ef.TimeoutInSecond);
			return bo;
		}

		public virtual List<BOLink> MapEFToBO(
			List<Link> records)
		{
			List<BOLink> response = new List<BOLink>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>00e993928f9a648b310dedd64ce277ac</Hash>
</Codenesium>*/