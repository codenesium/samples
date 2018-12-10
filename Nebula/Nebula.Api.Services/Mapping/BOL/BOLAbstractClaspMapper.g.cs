using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractClaspMapper
	{
		public virtual BOClasp MapModelToBO(
			int id,
			ApiClaspServerRequestModel model
			)
		{
			BOClasp boClasp = new BOClasp();
			boClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
			return boClasp;
		}

		public virtual ApiClaspServerResponseModel MapBOToModel(
			BOClasp boClasp)
		{
			var model = new ApiClaspServerResponseModel();

			model.SetProperties(boClasp.Id, boClasp.NextChainId, boClasp.PreviousChainId);

			return model;
		}

		public virtual List<ApiClaspServerResponseModel> MapBOToModel(
			List<BOClasp> items)
		{
			List<ApiClaspServerResponseModel> response = new List<ApiClaspServerResponseModel>();

			items.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6b178fea64c74caefddc8982c1d20e96</Hash>
</Codenesium>*/