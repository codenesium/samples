using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class DALAbstractUserMapper
	{
		public virtual User MapBOToEF(
			BOUser bo)
		{
			User efUser = new User();
			efUser.SetProperties(
				bo.Id,
				bo.Password,
				bo.Username,
				bo.IsDeleted);
			return efUser;
		}

		public virtual BOUser MapEFToBO(
			User ef)
		{
			var bo = new BOUser();

			bo.SetProperties(
				ef.Id,
				ef.Password,
				ef.Username,
				ef.IsDeleted);
			return bo;
		}

		public virtual List<BOUser> MapEFToBO(
			List<User> records)
		{
			List<BOUser> response = new List<BOUser>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d4723e4a25619aa6ae59a729f78b2afb</Hash>
</Codenesium>*/