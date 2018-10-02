using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractVoteMapper
	{
		public virtual BOVote MapModelToBO(
			int id,
			ApiVoteRequestModel model
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

		public virtual ApiVoteResponseModel MapBOToModel(
			BOVote boVote)
		{
			var model = new ApiVoteResponseModel();

			model.SetProperties(boVote.Id, boVote.BountyAmount, boVote.CreationDate, boVote.PostId, boVote.UserId, boVote.VoteTypeId);

			return model;
		}

		public virtual List<ApiVoteResponseModel> MapBOToModel(
			List<BOVote> items)
		{
			List<ApiVoteResponseModel> response = new List<ApiVoteResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>fd3ea7654dd69166cadec72efd95187e</Hash>
</Codenesium>*/