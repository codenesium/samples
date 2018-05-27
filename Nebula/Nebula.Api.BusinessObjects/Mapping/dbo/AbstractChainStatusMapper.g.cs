using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLChainStatusMapper
	{
		public virtual DTOChainStatus MapModelToDTO(
			int id,
			ApiChainStatusRequestModel model
			)
		{
			DTOChainStatus dtoChainStatus = new DTOChainStatus();

			dtoChainStatus.SetProperties(
				id,
				model.Name);
			return dtoChainStatus;
		}

		public virtual ApiChainStatusResponseModel MapDTOToModel(
			DTOChainStatus dtoChainStatus)
		{
			if (dtoChainStatus == null)
			{
				return null;
			}

			var model = new ApiChainStatusResponseModel();

			model.SetProperties(dtoChainStatus.Id, dtoChainStatus.Name);

			return model;
		}

		public virtual List<ApiChainStatusResponseModel> MapDTOToModel(
			List<DTOChainStatus> dtos)
		{
			List<ApiChainStatusResponseModel> response = new List<ApiChainStatusResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>8173791f5b67f2ae5ccba2a2a447eaec</Hash>
</Codenesium>*/