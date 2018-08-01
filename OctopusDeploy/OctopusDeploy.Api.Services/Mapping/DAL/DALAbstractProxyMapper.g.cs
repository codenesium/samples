using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractProxyMapper
	{
		public virtual Proxy MapBOToEF(
			BOProxy bo)
		{
			Proxy efProxy = new Proxy();
			efProxy.SetProperties(
				bo.Id,
				bo.JSON,
				bo.Name);
			return efProxy;
		}

		public virtual BOProxy MapEFToBO(
			Proxy ef)
		{
			var bo = new BOProxy();

			bo.SetProperties(
				ef.Id,
				ef.JSON,
				ef.Name);
			return bo;
		}

		public virtual List<BOProxy> MapEFToBO(
			List<Proxy> records)
		{
			List<BOProxy> response = new List<BOProxy>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>78a376bb38a9af0036fc0bdea481b557</Hash>
</Codenesium>*/