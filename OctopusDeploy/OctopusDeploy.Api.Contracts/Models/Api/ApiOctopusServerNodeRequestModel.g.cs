using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiOctopusServerNodeRequestModel : AbstractApiRequestModel
	{
		public ApiOctopusServerNodeRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			bool isInMaintenanceMode,
			string jSON,
			DateTimeOffset lastSeen,
			int maxConcurrentTasks,
			string name,
			string rank)
		{
			this.IsInMaintenanceMode = isInMaintenanceMode;
			this.JSON = jSON;
			this.LastSeen = lastSeen;
			this.MaxConcurrentTasks = maxConcurrentTasks;
			this.Name = name;
			this.Rank = rank;
		}

		[JsonProperty]
		public bool IsInMaintenanceMode { get; private set; }

		[JsonProperty]
		public string JSON { get; private set; }

		[JsonProperty]
		public DateTimeOffset LastSeen { get; private set; }

		[JsonProperty]
		public int MaxConcurrentTasks { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string Rank { get; private set; }
	}
}

/*<Codenesium>
    <Hash>44151b2ace629b17b46f51f82c8e01ad</Hash>
</Codenesium>*/