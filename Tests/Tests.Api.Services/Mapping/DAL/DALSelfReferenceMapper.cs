using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALSelfReferenceMapper : IDALSelfReferenceMapper
	{
		public virtual SelfReference MapModelToEntity(
			int id,
			ApiSelfReferenceServerRequestModel model
			)
		{
			SelfReference item = new SelfReference();
			item.SetProperties(
				id,
				model.SelfReferenceId,
				model.SelfReferenceId2);
			return item;
		}

		public virtual ApiSelfReferenceServerResponseModel MapEntityToModel(
			SelfReference item)
		{
			var model = new ApiSelfReferenceServerResponseModel();

			model.SetProperties(item.Id,
			                    item.SelfReferenceId,
			                    item.SelfReferenceId2);
			if (item.SelfReferenceIdNavigation != null)
			{
				var selfReferenceIdModel = new ApiSelfReferenceServerResponseModel();
				selfReferenceIdModel.SetProperties(
					item.SelfReferenceIdNavigation.Id,
					item.SelfReferenceIdNavigation.SelfReferenceId,
					item.SelfReferenceIdNavigation.SelfReferenceId2);

				model.SetSelfReferenceIdNavigation(selfReferenceIdModel);
			}

			if (item.SelfReferenceId2Navigation != null)
			{
				var selfReferenceId2Model = new ApiSelfReferenceServerResponseModel();
				selfReferenceId2Model.SetProperties(
					item.SelfReferenceId2Navigation.Id,
					item.SelfReferenceId2Navigation.SelfReferenceId,
					item.SelfReferenceId2Navigation.SelfReferenceId2);

				model.SetSelfReferenceId2Navigation(selfReferenceId2Model);
			}

			return model;
		}

		public virtual List<ApiSelfReferenceServerResponseModel> MapEntityToModel(
			List<SelfReference> items)
		{
			List<ApiSelfReferenceServerResponseModel> response = new List<ApiSelfReferenceServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a884b5ddd5a3bb2c8bf5da94f9e2afd8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/