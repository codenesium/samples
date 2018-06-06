using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractClaspMapper
	{
		public virtual BOClasp MapModelToBO(
			int id,
			ApiClaspRequestModel model
			)
		{
			BOClasp boClasp = new BOClasp();

			boClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
			return boClasp;
		}

		public virtual ApiClaspResponseModel MapBOToModel(
			BOClasp boClasp)
		{
			var model = new ApiClaspResponseModel();

			model.SetProperties(boClasp.Id, boClasp.NextChainId, boClasp.PreviousChainId);

			return model;
		}

		public virtual List<ApiClaspResponseModel> MapBOToModel(
			List<BOClasp> items)
		{
			List<ApiClaspResponseModel> response = new List<ApiClaspResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0534f48ed0d95ce6dc9178d546f84a67</Hash>
</Codenesium>*/