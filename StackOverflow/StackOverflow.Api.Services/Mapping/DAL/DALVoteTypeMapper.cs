using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public class DALVoteTypeMapper : IDALVoteTypeMapper
	{
		public virtual VoteType MapModelToEntity(
			int id,
			ApiVoteTypeServerRequestModel model
			)
		{
			VoteType item = new VoteType();
			item.SetProperties(
				id,
				model.Name);
			return item;
		}

		public virtual ApiVoteTypeServerResponseModel MapEntityToModel(
			VoteType item)
		{
			var model = new ApiVoteTypeServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Name);

			return model;
		}

		public virtual List<ApiVoteTypeServerResponseModel> MapEntityToModel(
			List<VoteType> items)
		{
			List<ApiVoteTypeServerResponseModel> response = new List<ApiVoteTypeServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>7e1ca669fe029496b9537d45be138218</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/