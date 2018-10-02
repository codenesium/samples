using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractBadgeMapper
	{
		public virtual Badge MapBOToEF(
			BOBadge bo)
		{
			Badge efBadge = new Badge();
			efBadge.SetProperties(
				bo.Date,
				bo.Id,
				bo.Name,
				bo.UserId);
			return efBadge;
		}

		public virtual BOBadge MapEFToBO(
			Badge ef)
		{
			var bo = new BOBadge();

			bo.SetProperties(
				ef.Id,
				ef.Date,
				ef.Name,
				ef.UserId);
			return bo;
		}

		public virtual List<BOBadge> MapEFToBO(
			List<Badge> records)
		{
			List<BOBadge> response = new List<BOBadge>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6b5ea0ed95b6f48a35a8fb86f7640d82</Hash>
</Codenesium>*/