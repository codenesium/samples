using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
	public abstract class BOLAbstractCommentsMapper
	{
		public virtual BOComments MapModelToBO(
			int id,
			ApiCommentsRequestModel model
			)
		{
			BOComments boComments = new BOComments();
			boComments.SetProperties(
				id,
				model.CreationDate,
				model.PostId,
				model.Score,
				model.Text,
				model.UserId);
			return boComments;
		}

		public virtual ApiCommentsResponseModel MapBOToModel(
			BOComments boComments)
		{
			var model = new ApiCommentsResponseModel();

			model.SetProperties(boComments.Id, boComments.CreationDate, boComments.PostId, boComments.Score, boComments.Text, boComments.UserId);

			return model;
		}

		public virtual List<ApiCommentsResponseModel> MapBOToModel(
			List<BOComments> items)
		{
			List<ApiCommentsResponseModel> response = new List<ApiCommentsResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c94d32d98b08b865630a3d14141fecea</Hash>
</Codenesium>*/