using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiWorkerRequestModel : AbstractApiRequestModel
	{
		public ApiWorkerRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string communicationStyle,
			string fingerprint,
			bool isDisabled,
			string jSON,
			string machinePolicyId,
			string name,
			string relatedDocumentIds,
			string thumbprint,
			string workerPoolIds)
		{
			this.CommunicationStyle = communicationStyle;
			this.Fingerprint = fingerprint;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.MachinePolicyId = machinePolicyId;
			this.Name = name;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Thumbprint = thumbprint;
			this.WorkerPoolIds = workerPoolIds;
		}

		[JsonProperty]
		public string CommunicationStyle { get; private set; }

		[JsonProperty]
		public string Fingerprint { get; private set; }

		[JsonProperty]
		public bool IsDisabled { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public string MachinePolicyId { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string RelatedDocumentIds { get; private set; }

		[JsonProperty]
		public string Thumbprint { get; private set; }

		[JsonProperty]
		public string WorkerPoolIds { get; private set; }
	}
}

/*<Codenesium>
    <Hash>962db52189a012579d4966ea03dbefad</Hash>
</Codenesium>*/