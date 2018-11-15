using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVoteMapper
	{
		public virtual BOVote MapModelToBO(
			int id,
			ApiVoteServerRequestModel model
			)
		{
			BOVote boVote = new BOVote();
			boVote.SetProperties(
				id,
				model.BountyAmount,
				model.CreationDate,
				model.PostId,
				model.UserId,
				model.VoteTypeId);
			return boVote;
		}

		public virtual ApiVoteServerResponseModel MapBOToModel(
			BOVote boVote)
		{
			var model = new ApiVoteServerResponseModel();

			model.SetProperties(boVote.Id, boVote.BountyAmount, boVote.CreationDate, boVote.PostId, boVote.UserId, boVote.VoteTypeId);

			return model;
		}

		public virtual List<ApiVoteServerResponseModel> MapBOToModel(
			List<BOVote> items)
		{
			List<ApiVoteServerResponseModel> response = new List<ApiVoteServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dd224201df24455a194e5b729cf46f27</Hash>
</Codenesium>*/