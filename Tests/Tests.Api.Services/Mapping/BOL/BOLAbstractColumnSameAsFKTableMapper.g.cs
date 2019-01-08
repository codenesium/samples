using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractColumnSameAsFKTableMapper
	{
		public virtual BOColumnSameAsFKTable MapModelToBO(
			int id,
			ApiColumnSameAsFKTableServerRequestModel model
			)
		{
			BOColumnSameAsFKTable boColumnSameAsFKTable = new BOColumnSameAsFKTable();
			boColumnSameAsFKTable.SetProperties(
				id,
				model.Person,
				model.PersonId);
			return boColumnSameAsFKTable;
		}

		public virtual ApiColumnSameAsFKTableServerResponseModel MapBOToModel(
			BOColumnSameAsFKTable boColumnSameAsFKTable)
		{
			var model = new ApiColumnSameAsFKTableServerResponseModel();

			model.SetProperties(boColumnSameAsFKTable.Id, boColumnSameAsFKTable.Person, boColumnSameAsFKTable.PersonId);

			return model;
		}

		public virtual List<ApiColumnSameAsFKTableServerResponseModel> MapBOToModel(
			List<BOColumnSameAsFKTable> items)
		{
			List<ApiColumnSameAsFKTableServerResponseModel> response = new List<ApiColumnSameAsFKTableServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>14ffb2b45ece44fddf5eddbe36aeef2e</Hash>
</Codenesium>*/