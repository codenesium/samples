using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiCertificateRequestModel : AbstractApiRequestModel
	{
		public ApiCertificateRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTimeOffset? archived,
			DateTimeOffset created,
			byte[] dataVersion,
			string environmentIds,
			string jSON,
			string name,
			DateTimeOffset notAfter,
			string subject,
			string tenantIds,
			string tenantTags,
			string thumbprint)
		{
			this.Archived = archived;
			this.Created = created;
			this.DataVersion = dataVersion;
			this.EnvironmentIds = environmentIds;
			this.JSON = jSON;
			this.Name = name;
			this.NotAfter = notAfter;
			this.Subject = subject;
			this.TenantIds = tenantIds;
			this.TenantTags = tenantTags;
			this.Thumbprint = thumbprint;
		}

		[JsonProperty]
		public DateTimeOffset? Archived { get; private set; }

		[JsonProperty]
		public DateTimeOffset Created { get; private set; }

		[JsonProperty]
		public byte[] DataVersion { get; private set; }

		[JsonProperty]
		public string EnvironmentIds { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public DateTimeOffset NotAfter { get; private set; }

		[JsonProperty]
		public string Subject { get; private set; }

		[JsonProperty]
		public string TenantIds { get; private set; }

		[JsonProperty]
		public string TenantTags { get; private set; }

		[JsonProperty]
		public string Thumbprint { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0d4ee97cf578e487220afffcc0e78558</Hash>
</Codenesium>*/