using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOLAWBuildVersionMapper
	{
		public virtual DTOAWBuildVersion MapModelToDTO(
			int systemInformationID,
			ApiAWBuildVersionRequestModel model
			)
		{
			DTOAWBuildVersion dtoAWBuildVersion = new DTOAWBuildVersion();

			dtoAWBuildVersion.SetProperties(
				systemInformationID,
				model.Database_Version,
				model.ModifiedDate,
				model.VersionDate);
			return dtoAWBuildVersion;
		}

		public virtual ApiAWBuildVersionResponseModel MapDTOToModel(
			DTOAWBuildVersion dtoAWBuildVersion)
		{
			if (dtoAWBuildVersion == null)
			{
				return null;
			}

			var model = new ApiAWBuildVersionResponseModel();

			model.SetProperties(dtoAWBuildVersion.Database_Version, dtoAWBuildVersion.ModifiedDate, dtoAWBuildVersion.SystemInformationID, dtoAWBuildVersion.VersionDate);

			return model;
		}

		public virtual List<ApiAWBuildVersionResponseModel> MapDTOToModel(
			List<DTOAWBuildVersion> dtos)
		{
			List<ApiAWBuildVersionResponseModel> response = new List<ApiAWBuildVersionResponseModel>();

			dtos.ForEach(d =>
			{
				response.Add(this.MapDTOToModel(d));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a60c8f4558b45dbfee5cf69bcbd3a781</Hash>
</Codenesium>*/