using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractVoteMapper
	{
		public virtual Vote MapBOToEF(
			BOVote bo)
		{
			Vote efVote = new Vote();
			efVote.SetProperties(
				bo.BountyAmount,
				bo.CreationDate,
				bo.Id,
				bo.PostId,
				bo.UserId,
				bo.VoteTypeId);
			return efVote;
		}

		public virtual BOVote MapEFToBO(
			Vote ef)
		{
			var bo = new BOVote();

			bo.SetProperties(
				ef.Id,
				ef.BountyAmount,
				ef.CreationDate,
				ef.PostId,
				ef.UserId,
				ef.VoteTypeId);
			return bo;
		}

		public virtual List<BOVote> MapEFToBO(
			List<Vote> records)
		{
			List<BOVote> response = new List<BOVote>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>679779235bc091191f8c01f078369ca3</Hash>
</Codenesium>*/