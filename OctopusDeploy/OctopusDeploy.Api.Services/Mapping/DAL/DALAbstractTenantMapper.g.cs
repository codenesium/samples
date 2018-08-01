using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractTenantMapper
	{
		public virtual Tenant MapBOToEF(
			BOTenant bo)
		{
			Tenant efTenant = new Tenant();
			efTenant.SetProperties(
				bo.DataVersion,
				bo.Id,
				bo.JSON,
				bo.Name,
				bo.ProjectIds,
				bo.TenantTags);
			return efTenant;
		}

		public virtual BOTenant MapEFToBO(
			Tenant ef)
		{
			var bo = new BOTenant();

			bo.SetProperties(
				ef.Id,
				ef.DataVersion,
				ef.JSON,
				ef.Name,
				ef.ProjectIds,
				ef.TenantTags);
			return bo;
		}

		public virtual List<BOTenant> MapEFToBO(
			List<Tenant> records)
		{
			List<BOTenant> response = new List<BOTenant>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dede02096d31a07a35ef17d37ab55ef9</Hash>
</Codenesium>*/