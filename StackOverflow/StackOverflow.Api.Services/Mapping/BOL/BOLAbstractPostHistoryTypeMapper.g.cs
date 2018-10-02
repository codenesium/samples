using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractPostHistoryTypeMapper
	{
		public virtual BOPostHistoryType MapModelToBO(
			int id,
			ApiPostHistoryTypeRequestModel model
			)
		{
			BOPostHistoryType boPostHistoryType = new BOPostHistoryType();
			boPostHistoryType.SetProperties(
				id,
				model.Type);
			return boPostHistoryType;
		}

		public virtual ApiPostHistoryTypeResponseModel MapBOToModel(
			BOPostHistoryType boPostHistoryType)
		{
			var model = new ApiPostHistoryTypeResponseModel();

			model.SetProperties(boPostHistoryType.Id, boPostHistoryType.Type);

			return model;
		}

		public virtual List<ApiPostHistoryTypeResponseModel> MapBOToModel(
			List<BOPostHistoryType> items)
		{
			List<ApiPostHistoryTypeResponseModel> response = new List<ApiPostHistoryTypeResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>10b14ce88f0622920bb6c07b28af37dc</Hash>
</Codenesium>*/