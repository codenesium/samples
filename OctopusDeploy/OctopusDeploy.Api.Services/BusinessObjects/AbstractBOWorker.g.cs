using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOWorker : AbstractBusinessObject
	{
		public AbstractBOWorker()
			: base()
		{
		}

		public virtual void SetProperties(string id,
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
			this.Id = id;
			this.IsDisabled = isDisabled;
			this.JSON = jSON;
			this.MachinePolicyId = machinePolicyId;
			this.Name = name;
			this.RelatedDocumentIds = relatedDocumentIds;
			this.Thumbprint = thumbprint;
			this.WorkerPoolIds = workerPoolIds;
		}

		public string CommunicationStyle { get; private set; }

		public string Fingerprint { get; private set; }

		public string Id { get; private set; }

		public bool IsDisabled { get; private set; }

		public string JSON { get; private set; }

		public string MachinePolicyId { get; private set; }

		public string Name { get; private set; }

		public string RelatedDocumentIds { get; private set; }

		public string Thumbprint { get; private set; }

		public string WorkerPoolIds { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9c1bdf8249d87de9c1f47c162215c6a9</Hash>
</Codenesium>*/