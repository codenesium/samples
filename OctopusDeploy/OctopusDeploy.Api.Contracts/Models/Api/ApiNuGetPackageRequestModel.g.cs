using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiNuGetPackageRequestModel : AbstractApiRequestModel
	{
		public ApiNuGetPackageRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string jSON,
			string packageId,
			string version,
			int versionBuild,
			int versionMajor,
			int versionMinor,
			int versionRevision,
			string versionSpecial)
		{
			this.JSON = jSON;
			this.PackageId = packageId;
			this.Version = version;
			this.VersionBuild = versionBuild;
			this.VersionMajor = versionMajor;
			this.VersionMinor = versionMinor;
			this.VersionRevision = versionRevision;
			this.VersionSpecial = versionSpecial;
		}

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string PackageId { get; private set; }

		[JsonProperty]
		public string Version { get; private set; }

		[JsonProperty]
		public int VersionBuild { get; private set; }

		[JsonProperty]
		public int VersionMajor { get; private set; }

		[JsonProperty]
		public int VersionMinor { get; private set; }

		[JsonProperty]
		public int VersionRevision { get; private set; }

		[JsonProperty]
		public string VersionSpecial { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9974ad714654962dd3a237ad32693787</Hash>
</Codenesium>*/