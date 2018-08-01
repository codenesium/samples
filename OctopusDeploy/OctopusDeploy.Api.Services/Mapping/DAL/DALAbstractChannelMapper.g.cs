using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractChannelMapper
	{
		public virtual Channel MapBOToEF(
			BOChannel bo)
		{
			Channel efChannel = new Channel();
			efChannel.SetProperties(
				bo.DataVersion,
				bo.Id,
				bo.JSON,
				bo.LifecycleId,
				bo.Name,
				bo.ProjectId,
				bo.TenantTags);
			return efChannel;
		}

		public virtual BOChannel MapEFToBO(
			Channel ef)
		{
			var bo = new BOChannel();

			bo.SetProperties(
				ef.Id,
				ef.DataVersion,
				ef.JSON,
				ef.LifecycleId,
				ef.Name,
				ef.ProjectId,
				ef.TenantTags);
			return bo;
		}

		public virtual List<BOChannel> MapEFToBO(
			List<Channel> records)
		{
			List<BOChannel> response = new List<BOChannel>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>30592cec8c84ba90df4dce7de63bfedc</Hash>
</Codenesium>*/