using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVotesMapper
	{
		public virtual BOVotes MapModelToBO(
			int id,
			ApiVotesRequestModel model
			)
		{
			BOVotes boVotes = new BOVotes();
			boVotes.SetProperties(
				id,
				model.BountyAmount,
				model.CreationDate,
				model.PostId,
				model.UserId,
				model.VoteTypeId);
			return boVotes;
		}

		public virtual ApiVotesResponseModel MapBOToModel(
			BOVotes boVotes)
		{
			var model = new ApiVotesResponseModel();

			model.SetProperties(boVotes.Id, boVotes.BountyAmount, boVotes.CreationDate, boVotes.PostId, boVotes.UserId, boVotes.VoteTypeId);

			return model;
		}

		public virtual List<ApiVotesResponseModel> MapBOToModel(
			List<BOVotes> items)
		{
			List<ApiVotesResponseModel> response = new List<ApiVotesResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cd0ad0ec5b25d2446f90c37059495909</Hash>
</Codenesium>*/