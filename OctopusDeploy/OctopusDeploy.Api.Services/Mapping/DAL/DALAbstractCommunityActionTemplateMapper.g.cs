using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractCommunityActionTemplateMapper
	{
		public virtual CommunityActionTemplate MapBOToEF(
			BOCommunityActionTemplate bo)
		{
			CommunityActionTemplate efCommunityActionTemplate = new CommunityActionTemplate();
			efCommunityActionTemplate.SetProperties(
				bo.ExternalId,
				bo.Id,
				bo.JSON,
				bo.Name);
			return efCommunityActionTemplate;
		}

		public virtual BOCommunityActionTemplate MapEFToBO(
			CommunityActionTemplate ef)
		{
			var bo = new BOCommunityActionTemplate();

			bo.SetProperties(
				ef.Id,
				ef.ExternalId,
				ef.JSON,
				ef.Name);
			return bo;
		}

		public virtual List<BOCommunityActionTemplate> MapEFToBO(
			List<CommunityActionTemplate> records)
		{
			List<BOCommunityActionTemplate> response = new List<BOCommunityActionTemplate>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>88cfc243779b629ba766948496529673</Hash>
</Codenesium>*/