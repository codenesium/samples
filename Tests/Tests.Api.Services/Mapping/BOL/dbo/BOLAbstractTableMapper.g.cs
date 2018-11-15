using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractTableMapper
	{
		public virtual BOTable MapModelToBO(
			int id,
			ApiTableServerRequestModel model
			)
		{
			BOTable boTable = new BOTable();
			boTable.SetProperties(
				id,
				model.Name);
			return boTable;
		}

		public virtual ApiTableServerResponseModel MapBOToModel(
			BOTable boTable)
		{
			var model = new ApiTableServerResponseModel();

			model.SetProperties(boTable.Id, boTable.Name);

			return model;
		}

		public virtual List<ApiTableServerResponseModel> MapBOToModel(
			List<BOTable> items)
		{
			List<ApiTableServerResponseModel> response = new List<ApiTableServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0f4845e60b58536d3ade4292fb710e1a</Hash>
</Codenesium>*/