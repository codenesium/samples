using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiNuGetPackageModelMapper
	{
		public virtual ApiNuGetPackageResponseModel MapRequestToResponse(
			string id,
			ApiNuGetPackageRequestModel request)
		{
			var response = new ApiNuGetPackageResponseModel();
			response.SetProperties(id,
			                       request.JSON,
			                       request.PackageId,
			                       request.Version,
			                       request.VersionBuild,
			                       request.VersionMajor,
			                       request.VersionMinor,
			                       request.VersionRevision,
			                       request.VersionSpecial);
			return response;
		}

		public virtual ApiNuGetPackageRequestModel MapResponseToRequest(
			ApiNuGetPackageResponseModel response)
		{
			var request = new ApiNuGetPackageRequestModel();
			request.SetProperties(
				response.JSON,
				response.PackageId,
				response.Version,
				response.VersionBuild,
				response.VersionMajor,
				response.VersionMinor,
				response.VersionRevision,
				response.VersionSpecial);
			return request;
		}

		public JsonPatchDocument<ApiNuGetPackageRequestModel> CreatePatch(ApiNuGetPackageRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiNuGetPackageRequestModel>();
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.PackageId, model.PackageId);
			patch.Replace(x => x.Version, model.Version);
			patch.Replace(x => x.VersionBuild, model.VersionBuild);
			patch.Replace(x => x.VersionMajor, model.VersionMajor);
			patch.Replace(x => x.VersionMinor, model.VersionMinor);
			patch.Replace(x => x.VersionRevision, model.VersionRevision);
			patch.Replace(x => x.VersionSpecial, model.VersionSpecial);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>2545fa53ea2450571b72a1d1dbba15d9</Hash>
</Codenesium>*/