using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.Services
{
	public abstract class BOLAbstractLinkStatusMapper
	{
		public virtual BOLinkStatus MapModelToBO(
			int id,
			ApiLinkStatusRequestModel model
			)
		{
			BOLinkStatus BOLinkStatus = new BOLinkStatus();

			BOLinkStatus.SetProperties(
				id,
				model.Name);
			return BOLinkStatus;
		}

		public virtual ApiLinkStatusResponseModel MapBOToModel(
			BOLinkStatus BOLinkStatus)
		{
			if (BOLinkStatus == null)
			{
				return null;
			}

			var model = new ApiLinkStatusResponseModel();

			model.SetProperties(BOLinkStatus.Id, BOLinkStatus.Name);

			return model;
		}

		public virtual List<ApiLinkStatusResponseModel> MapBOToModel(
			List<BOLinkStatus> BOs)
		{
			List<ApiLinkStatusResponseModel> response = new List<ApiLinkStatusResponseModel>();

			BOs.ForEach(d =>
			{
				response.Add(this.MapBOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>b21d75003065a0ec759e19409d739270</Hash>
</Codenesium>*/