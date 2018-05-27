using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLinkStatusMapper
	{
		public virtual DTOLinkStatus MapModelToDTO(
			int id,
			ApiLinkStatusRequestModel model
			)
		{
			DTOLinkStatus dtoLinkStatus = new DTOLinkStatus();

			dtoLinkStatus.SetProperties(
				id,
				model.Name);
			return dtoLinkStatus;
		}

		public virtual ApiLinkStatusResponseModel MapDTOToModel(
			DTOLinkStatus dtoLinkStatus)
		{
			if (dtoLinkStatus == null)
			{
				return null;
			}

			var model = new ApiLinkStatusResponseModel();

			model.SetProperties(dtoLinkStatus.Id, dtoLinkStatus.Name);

			return model;
		}

		public virtual List<ApiLinkStatusResponseModel> MapDTOToModel(
			List<DTOLinkStatus> dtos)
		{
			List<ApiLinkStatusResponseModel> response = new List<ApiLinkStatusResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>4e896cda8d658d5bdee3bdc69f16afa2</Hash>
</Codenesium>*/