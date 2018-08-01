using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractVotesMapper
	{
		public virtual Votes MapBOToEF(
			BOVotes bo)
		{
			Votes efVotes = new Votes();
			efVotes.SetProperties(
				bo.BountyAmount,
				bo.CreationDate,
				bo.Id,
				bo.PostId,
				bo.UserId,
				bo.VoteTypeId);
			return efVotes;
		}

		public virtual BOVotes MapEFToBO(
			Votes ef)
		{
			var bo = new BOVotes();

			bo.SetProperties(
				ef.Id,
				ef.BountyAmount,
				ef.CreationDate,
				ef.PostId,
				ef.UserId,
				ef.VoteTypeId);
			return bo;
		}

		public virtual List<BOVotes> MapEFToBO(
			List<Votes> records)
		{
			List<BOVotes> response = new List<BOVotes>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c2b3be18e09f09fa2284603994462420</Hash>
</Codenesium>*/