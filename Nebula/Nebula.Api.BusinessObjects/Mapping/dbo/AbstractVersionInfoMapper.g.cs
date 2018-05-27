using System;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOLVersionInfoMapper
	{
		public virtual DTOVersionInfo MapModelToDTO(
			long version,
			ApiVersionInfoRequestModel model
			)
		{
			DTOVersionInfo dtoVersionInfo = new DTOVersionInfo();

			dtoVersionInfo.SetProperties(
				version,
				model.AppliedOn,
				model.Description);
			return dtoVersionInfo;
		}

		public virtual ApiVersionInfoResponseModel MapDTOToModel(
			DTOVersionInfo dtoVersionInfo)
		{
			if (dtoVersionInfo == null)
			{
				return null;
			}

			var model = new ApiVersionInfoResponseModel();

			model.SetProperties(dtoVersionInfo.AppliedOn, dtoVersionInfo.Description, dtoVersionInfo.Version);

			return model;
		}

		public virtual List<ApiVersionInfoResponseModel> MapDTOToModel(
			List<DTOVersionInfo> dtos)
		{
			List<ApiVersionInfoResponseModel> response = new List<ApiVersionInfoResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>228ea2350c3bf8faccb087804673d031</Hash>
</Codenesium>*/