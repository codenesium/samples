using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractActionTemplateMapper
	{
		public virtual ActionTemplate MapBOToEF(
			BOActionTemplate bo)
		{
			ActionTemplate efActionTemplate = new ActionTemplate();
			efActionTemplate.SetProperties(
				bo.ActionType,
				bo.CommunityActionTemplateId,
				bo.Id,
				bo.JSON,
				bo.Name,
				bo.Version);
			return efActionTemplate;
		}

		public virtual BOActionTemplate MapEFToBO(
			ActionTemplate ef)
		{
			var bo = new BOActionTemplate();

			bo.SetProperties(
				ef.Id,
				ef.ActionType,
				ef.CommunityActionTemplateId,
				ef.JSON,
				ef.Name,
				ef.Version);
			return bo;
		}

		public virtual List<BOActionTemplate> MapEFToBO(
			List<ActionTemplate> records)
		{
			List<BOActionTemplate> response = new List<BOActionTemplate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8debb09b2052fca178926fd6d0099a55</Hash>
</Codenesium>*/