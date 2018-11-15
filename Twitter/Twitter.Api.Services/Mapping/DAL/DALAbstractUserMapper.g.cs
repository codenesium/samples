using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class DALAbstractUserMapper
	{
		public virtual User MapBOToEF(
			BOUser bo)
		{
			User efUser = new User();
			efUser.SetProperties(
				bo.BioImgUrl,
				bo.Birthday,
				bo.ContentDescription,
				bo.Email,
				bo.FullName,
				bo.HeaderImgUrl,
				bo.Interest,
				bo.LocationLocationId,
				bo.Password,
				bo.PhoneNumber,
				bo.Privacy,
				bo.UserId,
				bo.Username,
				bo.Website);
			return efUser;
		}

		public virtual BOUser MapEFToBO(
			User ef)
		{
			var bo = new BOUser();

			bo.SetProperties(
				ef.UserId,
				ef.BioImgUrl,
				ef.Birthday,
				ef.ContentDescription,
				ef.Email,
				ef.FullName,
				ef.HeaderImgUrl,
				ef.Interest,
				ef.LocationLocationId,
				ef.Password,
				ef.PhoneNumber,
				ef.Privacy,
				ef.Username,
				ef.Website);
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
    <Hash>4279cfc09c430c3b2b2120a748f2e643</Hash>
</Codenesium>*/