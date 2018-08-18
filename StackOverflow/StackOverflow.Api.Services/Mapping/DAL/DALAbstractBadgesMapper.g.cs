using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractBadgesMapper
	{
		public virtual Badges MapBOToEF(
			BOBadges bo)
		{
			Badges efBadges = new Badges();
			efBadges.SetProperties(
				bo.Date,
				bo.Id,
				bo.Name,
				bo.UserId);
			return efBadges;
		}

		public virtual BOBadges MapEFToBO(
			Badges ef)
		{
			var bo = new BOBadges();

			bo.SetProperties(
				ef.Id,
				ef.Date,
				ef.Name,
				ef.UserId);
			return bo;
		}

		public virtual List<BOBadges> MapEFToBO(
			List<Badges> records)
		{
			List<BOBadges> response = new List<BOBadges>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ab1d5f89a07d650779a9d33bb5b18f4e</Hash>
</Codenesium>*/