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
			BOClasp BOClasp = new BOClasp();

			BOClasp.SetProperties(
				id,
				model.NextChainId,
				model.PreviousChainId);
			return BOClasp;
		}

		public virtual ApiClaspResponseModel MapBOToModel(
			BOClasp BOClasp)
		{
			if (BOClasp == null)
			{
				return null;
			}

			var model = new ApiClaspResponseModel();

			model.SetProperties(BOClasp.Id, BOClasp.NextChainId, BOClasp.PreviousChainId);

			return model;
		}

		public virtual List<ApiClaspResponseModel> MapBOToModel(
			List<BOClasp> BOs)
		{
			List<ApiClaspResponseModel> response = new List<ApiClaspResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2d19e4ffe3da8d85adcf0f383332d0d7</Hash>
</Codenesium>*/