using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public class DALVPersonMapper : IDALVPersonMapper
	{
		public virtual VPerson MapModelToEntity(
			int personId,
			ApiVPersonServerRequestModel model
			)
		{
			VPerson item = new VPerson();
			item.SetProperties(
				personId,
				model.PersonName);
			return item;
		}

		public virtual ApiVPersonServerResponseModel MapEntityToModel(
			VPerson item)
		{
			var model = new ApiVPersonServerResponseModel();

			model.SetProperties(item.PersonId,
			                    item.PersonName);

			return model;
		}

		public virtual List<ApiVPersonServerResponseModel> MapEntityToModel(
			List<VPerson> items)
		{
			List<ApiVPersonServerResponseModel> response = new List<ApiVPersonServerResponseModel>();

			items.ForEach(x =>
			{
				response.Add(this.MapEntityToModel(x));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0ac3a7116616bb7ff708a8cc16db78db</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/