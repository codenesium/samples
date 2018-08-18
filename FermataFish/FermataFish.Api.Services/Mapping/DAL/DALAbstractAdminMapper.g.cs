using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
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
				bo.StudioId);
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
				ef.StudioId);
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
    <Hash>91c6c2e34fdbd78668ca5b2181695f4f</Hash>
</Codenesium>*/