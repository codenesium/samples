using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALColumnSameAsFKTableMapper : IDALColumnSameAsFKTableMapper
	{
		public virtual ColumnSameAsFKTable MapModelToEntity(
			int id,
			ApiColumnSameAsFKTableServerRequestModel model
			)
		{
			ColumnSameAsFKTable item = new ColumnSameAsFKTable();
			item.SetProperties(
				id,
				model.Person,
				model.PersonId);
			return item;
		}

		public virtual ApiColumnSameAsFKTableServerResponseModel MapEntityToModel(
			ColumnSameAsFKTable item)
		{
			var model = new ApiColumnSameAsFKTableServerResponseModel();

			model.SetProperties(item.Id,
			                    item.Person,
			                    item.PersonId);
			if (item.PersonNavigation != null)
			{
				var personModel = new ApiPersonServerResponseModel();
				personModel.SetProperties(
					item.PersonNavigation.PersonId,
					item.PersonNavigation.PersonName);

				model.SetPersonNavigation(personModel);
			}

			if (item.PersonIdNavigation != null)
			{
				var personIdModel = new ApiPersonServerResponseModel();
				personIdModel.SetProperties(
					item.PersonIdNavigation.PersonId,
					item.PersonIdNavigation.PersonName);

				model.SetPersonIdNavigation(personIdModel);
			}

			return model;
		}

		public virtual List<ApiColumnSameAsFKTableServerResponseModel> MapEntityToModel(
			List<ColumnSameAsFKTable> items)
		{
			List<ApiColumnSameAsFKTableServerResponseModel> response = new List<ApiColumnSameAsFKTableServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>35a1c8e535a3747acbf7b338695e76f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/