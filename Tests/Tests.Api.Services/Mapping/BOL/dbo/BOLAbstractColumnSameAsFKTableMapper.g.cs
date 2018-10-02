using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public abstract class BOLAbstractColumnSameAsFKTableMapper
	{
		public virtual BOColumnSameAsFKTable MapModelToBO(
			int id,
			ApiColumnSameAsFKTableRequestModel model
			)
		{
			BOColumnSameAsFKTable boColumnSameAsFKTable = new BOColumnSameAsFKTable();
			boColumnSameAsFKTable.SetProperties(
				id,
				model.Person,
				model.PersonId);
			return boColumnSameAsFKTable;
		}

		public virtual ApiColumnSameAsFKTableResponseModel MapBOToModel(
			BOColumnSameAsFKTable boColumnSameAsFKTable)
		{
			var model = new ApiColumnSameAsFKTableResponseModel();

			model.SetProperties(boColumnSameAsFKTable.Id, boColumnSameAsFKTable.Person, boColumnSameAsFKTable.PersonId);

			return model;
		}

		public virtual List<ApiColumnSameAsFKTableResponseModel> MapBOToModel(
			List<BOColumnSameAsFKTable> items)
		{
			List<ApiColumnSameAsFKTableResponseModel> response = new List<ApiColumnSameAsFKTableResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>224df4bc3c539cf447efefd75bca5f02</Hash>
</Codenesium>*/