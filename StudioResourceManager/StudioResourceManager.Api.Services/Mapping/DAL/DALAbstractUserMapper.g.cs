using Microsoft.EntityFrameworkCore;
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
				bo.Username);
			return efUser;
		}

		public virtual BOUser MapEFToBO(
			User ef)
		{
			var bo = new BOUser();

			bo.SetProperties(
				ef.Id,
				ef.Password,
				ef.Username);
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
    <Hash>71e4c889a9aba58b65f75bda3da8a570</Hash>
</Codenesium>*/