using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostHistoryTypeMapper
	{
		public virtual BOPostHistoryType MapModelToBO(
			int id,
			ApiPostHistoryTypeServerRequestModel model
			)
		{
			BOPostHistoryType boPostHistoryType = new BOPostHistoryType();
			boPostHistoryType.SetProperties(
				id,
				model.Type);
			return boPostHistoryType;
		}

		public virtual ApiPostHistoryTypeServerResponseModel MapBOToModel(
			BOPostHistoryType boPostHistoryType)
		{
			var model = new ApiPostHistoryTypeServerResponseModel();

			model.SetProperties(boPostHistoryType.Id, boPostHistoryType.Type);

			return model;
		}

		public virtual List<ApiPostHistoryTypeServerResponseModel> MapBOToModel(
			List<BOPostHistoryType> items)
		{
			List<ApiPostHistoryTypeServerResponseModel> response = new List<ApiPostHistoryTypeServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>96de3eae54bd8413b99a4c3759e91bcd</Hash>
</Codenesium>*/