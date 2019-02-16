using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractDALVoteMapper
	{
		public virtual Vote MapModelToEntity(
			int id,
			ApiVoteServerRequestModel model
			)
		{
			Vote item = new Vote();
			item.SetProperties(
				id,
				model.BountyAmount,
				model.CreationDate,
				model.PostId,
				model.UserId,
				model.VoteTypeId);
			return item;
		}

		public virtual ApiVoteServerResponseModel MapEntityToModel(
			Vote item)
		{
			var model = new ApiVoteServerResponseModel();

			model.SetProperties(item.Id,
			                    item.BountyAmount,
			                    item.CreationDate,
			                    item.PostId,
			                    item.UserId,
			                    item.VoteTypeId);

			return model;
		}

		public virtual List<ApiVoteServerResponseModel> MapEntityToModel(
			List<Vote> items)
		{
			List<ApiVoteServerResponseModel> response = new List<ApiVoteServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9ef5e9892ecec16f7b24efd6159fee30</Hash>
</Codenesium>*/