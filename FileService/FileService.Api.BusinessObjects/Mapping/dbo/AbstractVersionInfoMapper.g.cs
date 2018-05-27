using System;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.BusinessObjects
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
    <Hash>5619d0cb8b843edb691e4c48e18a7dfc</Hash>
</Codenesium>*/