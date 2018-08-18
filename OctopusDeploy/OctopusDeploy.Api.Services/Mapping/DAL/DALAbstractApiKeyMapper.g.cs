using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractApiKeyMapper
	{
		public virtual ApiKey MapBOToEF(
			BOApiKey bo)
		{
			ApiKey efApiKey = new ApiKey();
			efApiKey.SetProperties(
				bo.ApiKeyHashed,
				bo.Created,
				bo.Id,
				bo.JSON,
				bo.UserId);
			return efApiKey;
		}

		public virtual BOApiKey MapEFToBO(
			ApiKey ef)
		{
			var bo = new BOApiKey();

			bo.SetProperties(
				ef.Id,
				ef.ApiKeyHashed,
				ef.Created,
				ef.JSON,
				ef.UserId);
			return bo;
		}

		public virtual List<BOApiKey> MapEFToBO(
			List<ApiKey> records)
		{
			List<BOApiKey> response = new List<BOApiKey>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>911522dcb0e99685de77aadb2f420870</Hash>
</Codenesium>*/