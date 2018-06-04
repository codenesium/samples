using System;
using System.Collections.Generic;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
namespace PetStoreNS.Api.Services
{
	public abstract class BOLAbstractBreedMapper
	{
		public virtual BOBreed MapModelToBO(
			int id,
			ApiBreedRequestModel model
			)
		{
			BOBreed BOBreed = new BOBreed();

			BOBreed.SetProperties(
				id,
				model.Name);
			return BOBreed;
		}

		public virtual ApiBreedResponseModel MapBOToModel(
			BOBreed BOBreed)
		{
			if (BOBreed == null)
			{
				return null;
			}

			var model = new ApiBreedResponseModel();

			model.SetProperties(BOBreed.Id, BOBreed.Name);

			return model;
		}

		public virtual List<ApiBreedResponseModel> MapBOToModel(
			List<BOBreed> BOs)
		{
			List<ApiBreedResponseModel> response = new List<ApiBreedResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>79ff1a1bd50ac244e8c2c7e0fc5e09da</Hash>
</Codenesium>*/