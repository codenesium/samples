using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLLinkLogMapper
	{
		public virtual DTOLinkLog MapModelToDTO(
			int id,
			ApiLinkLogRequestModel model
			)
		{
			DTOLinkLog dtoLinkLog = new DTOLinkLog();

			dtoLinkLog.SetProperties(
				id,
				model.DateEntered,
				model.LinkId,
				model.Log);
			return dtoLinkLog;
		}

		public virtual ApiLinkLogResponseModel MapDTOToModel(
			DTOLinkLog dtoLinkLog)
		{
			if (dtoLinkLog == null)
			{
				return null;
			}

			var model = new ApiLinkLogResponseModel();

			model.SetProperties(dtoLinkLog.DateEntered, dtoLinkLog.Id, dtoLinkLog.LinkId, dtoLinkLog.Log);

			return model;
		}

		public virtual List<ApiLinkLogResponseModel> MapDTOToModel(
			List<DTOLinkLog> dtos)
		{
			List<ApiLinkLogResponseModel> response = new List<ApiLinkLogResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>dbfb7e157a6426a58dd4b24563379cf3</Hash>
</Codenesium>*/