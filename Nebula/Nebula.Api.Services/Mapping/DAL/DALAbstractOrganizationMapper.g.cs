using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class DALAbstractOrganizationMapper
	{
		public virtual Organization MapBOToEF(
			BOOrganization bo)
		{
			Organization efOrganization = new Organization();
			efOrganization.SetProperties(
				bo.Id,
				bo.Name);
			return efOrganization;
		}

		public virtual BOOrganization MapEFToBO(
			Organization ef)
		{
			var bo = new BOOrganization();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOOrganization> MapEFToBO(
			List<Organization> records)
		{
			List<BOOrganization> response = new List<BOOrganization>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a6dc51cd893ce5a88276efe24d9563ba</Hash>
</Codenesium>*/