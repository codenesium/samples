using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractTenantMapper
	{
		public virtual Tenant MapBOToEF(
			BOTenant bo)
		{
			Tenant efTenant = new Tenant();
			efTenant.SetProperties(
				bo.Id,
				bo.Name);
			return efTenant;
		}

		public virtual BOTenant MapEFToBO(
			Tenant ef)
		{
			var bo = new BOTenant();

			bo.SetProperties(
				ef.Id,
				ef.Name);
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
    <Hash>20d518d5611597249655e23602573d14</Hash>
</Codenesium>*/