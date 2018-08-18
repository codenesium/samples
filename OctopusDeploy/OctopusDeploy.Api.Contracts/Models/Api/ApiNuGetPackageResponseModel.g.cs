using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiNuGetPackageResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
			string jSON,
			string packageId,
			string version,
			int versionBuild,
			int versionMajor,
			int versionMinor,
			int versionRevision,
			string versionSpecial)
		{
			this.Id = id;
			this.JSON = jSON;
			this.PackageId = packageId;
			this.Version = version;
			this.VersionBuild = versionBuild;
			this.VersionMajor = versionMajor;
			this.VersionMinor = versionMinor;
			this.VersionRevision = versionRevision;
			this.VersionSpecial = versionSpecial;
		}

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public string PackageId { get; private set; }

		[Required]
		[JsonProperty]
		public string Version { get; private set; }

		[Required]
		[JsonProperty]
		public int VersionBuild { get; private set; }

		[Required]
		[JsonProperty]
		public int VersionMajor { get; private set; }

		[Required]
		[JsonProperty]
		public int VersionMinor { get; private set; }

		[Required]
		[JsonProperty]
		public int VersionRevision { get; private set; }

		[Required]
		[JsonProperty]
		public string VersionSpecial { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f9a824ac46d4eb22e1d56d707722aec</Hash>
</Codenesium>*/