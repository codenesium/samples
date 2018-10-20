using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractAdminMapper
	{
		public virtual Admin MapBOToEF(
			BOAdmin bo)
		{
			Admin efAdmin = new Admin();
			efAdmin.SetProperties(
				bo.Birthday,
				bo.Email,
				bo.FirstName,
				bo.Id,
				bo.LastName,
				bo.Phone,
				bo.UserId,
				bo.IsDeleted);
			return efAdmin;
		}

		public virtual BOAdmin MapEFToBO(
			Admin ef)
		{
			var bo = new BOAdmin();

			bo.SetProperties(
				ef.Id,
				ef.Birthday,
				ef.Email,
				ef.FirstName,
				ef.LastName,
				ef.Phone,
				ef.UserId,
				ef.IsDeleted);
			return bo;
		}

		public virtual List<BOAdmin> MapEFToBO(
			List<Admin> records)
		{
			List<BOAdmin> response = new List<BOAdmin>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8a765c88c7d66652962aea4f2bdcef86</Hash>
</Codenesium>*/