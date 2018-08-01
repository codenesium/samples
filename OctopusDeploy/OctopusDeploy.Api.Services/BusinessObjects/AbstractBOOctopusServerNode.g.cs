using Codenesium.DataConversionExtensions;
using System;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractBOOctopusServerNode : AbstractBusinessObject
	{
		public AbstractBOOctopusServerNode()
			: base()
		{
		}

		public virtual void SetProperties(string id,
		                                  bool isInMaintenanceMode,
		                                  string jSON,
		                                  DateTimeOffset lastSeen,
		                                  int maxConcurrentTasks,
		                                  string name,
		                                  string rank)
		{
			this.Id = id;
			this.IsInMaintenanceMode = isInMaintenanceMode;
			this.JSON = jSON;
			this.LastSeen = lastSeen;
			this.MaxConcurrentTasks = maxConcurrentTasks;
			this.Name = name;
			this.Rank = rank;
		}

		public string Id { get; private set; }

		public bool IsInMaintenanceMode { get; private set; }

		public string JSON { get; private set; }

		public DateTimeOffset LastSeen { get; private set; }

		public int MaxConcurrentTasks { get; private set; }

		public string Name { get; private set; }

		public string Rank { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1654e1e31861f5a5d46cabf753dbdf70</Hash>
</Codenesium>*/