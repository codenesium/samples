using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLinkMapper
	{
		public virtual DTOLink MapModelToDTO(
			int id,
			ApiLinkRequestModel model
			)
		{
			DTOLink dtoLink = new DTOLink();

			dtoLink.SetProperties(
				id,
				model.AssignedMachineId,
				model.ChainId,
				model.DateCompleted,
				model.DateStarted,
				model.DynamicParameters,
				model.ExternalId,
				model.LinkStatusId,
				model.Name,
				model.Order,
				model.Response,
				model.StaticParameters,
				model.TimeoutInSeconds);
			return dtoLink;
		}

		public virtual ApiLinkResponseModel MapDTOToModel(
			DTOLink dtoLink)
		{
			if (dtoLink == null)
			{
				return null;
			}

			var model = new ApiLinkResponseModel();

			model.SetProperties(dtoLink.AssignedMachineId, dtoLink.ChainId, dtoLink.DateCompleted, dtoLink.DateStarted, dtoLink.DynamicParameters, dtoLink.ExternalId, dtoLink.Id, dtoLink.LinkStatusId, dtoLink.Name, dtoLink.Order, dtoLink.Response, dtoLink.StaticParameters, dtoLink.TimeoutInSeconds);

			return model;
		}

		public virtual List<ApiLinkResponseModel> MapDTOToModel(
			List<DTOLink> dtos)
		{
			List<ApiLinkResponseModel> response = new List<ApiLinkResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e9701491ab97f5b7f13b57207b862b49</Hash>
</Codenesium>*/