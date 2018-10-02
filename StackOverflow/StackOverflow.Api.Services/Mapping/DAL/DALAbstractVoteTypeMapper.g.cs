using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class DALAbstractVoteTypeMapper
	{
		public virtual VoteType MapBOToEF(
			BOVoteType bo)
		{
			VoteType efVoteType = new VoteType();
			efVoteType.SetProperties(
				bo.Id,
				bo.Name);
			return efVoteType;
		}

		public virtual BOVoteType MapEFToBO(
			VoteType ef)
		{
			var bo = new BOVoteType();

			bo.SetProperties(
				ef.Id,
				ef.Name);
			return bo;
		}

		public virtual List<BOVoteType> MapEFToBO(
			List<VoteType> records)
		{
			List<BOVoteType> response = new List<BOVoteType>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>1124b2f76d317f338896e828d4cab4fa</Hash>
</Codenesium>*/