using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOWorkerTaskLease : AbstractBusinessObject
	{
		public AbstractBOWorkerTaskLease()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  bool exclusive,
		                                  string jSON,
		                                  string name,
		                                  string taskId,
		                                  string workerId)
		{
			this.Exclusive = exclusive;
			this.Id = id;
			this.JSON = jSON;
			this.Name = name;
			this.TaskId = taskId;
			this.WorkerId = workerId;
		}

		public bool Exclusive { get; private set; }

		public string Id { get; private set; }

		public string JSON { get; private set; }

		public string Name { get; private set; }

		public string TaskId { get; private set; }

		public string WorkerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8d53c8f9b2386eaaec68d13c6278f011</Hash>
</Codenesium>*/