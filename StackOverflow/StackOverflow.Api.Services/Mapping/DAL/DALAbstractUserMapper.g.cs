using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractUserMapper
	{
		public virtual User MapBOToEF(
			BOUser bo)
		{
			User efUser = new User();
			efUser.SetProperties(
				bo.AboutMe,
				bo.AccountId,
				bo.Age,
				bo.CreationDate,
				bo.DisplayName,
				bo.DownVote,
				bo.EmailHash,
				bo.Id,
				bo.LastAccessDate,
				bo.Location,
				bo.Reputation,
				bo.UpVote,
				bo.View,
				bo.WebsiteUrl);
			return efUser;
		}

		public virtual BOUser MapEFToBO(
			User ef)
		{
			var bo = new BOUser();

			bo.SetProperties(
				ef.Id,
				ef.AboutMe,
				ef.AccountId,
				ef.Age,
				ef.CreationDate,
				ef.DisplayName,
				ef.DownVote,
				ef.EmailHash,
				ef.LastAccessDate,
				ef.Location,
				ef.Reputation,
				ef.UpVote,
				ef.View,
				ef.WebsiteUrl);
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
    <Hash>c15e944e361ca0c32cf8ae185f85444d</Hash>
</Codenesium>*/