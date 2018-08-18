using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Contracts
{
	public partial class ApiOctopusServerNodeResponseModel : AbstractApiResponseModel
	{
		public virtual void SetProperties(
			string id,
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

		[Required]
		[JsonProperty]
		public string Id { get; private set; }

		[Required]
		[JsonProperty]
		public bool IsInMaintenanceMode { get; private set; }

		[Required]
		[JsonProperty]
		public string JSON { get; private set; }

		[Required]
		[JsonProperty]
		public DateTimeOffset LastSeen { get; private set; }

		[Required]
		[JsonProperty]
		public int MaxConcurrentTasks { get; private set; }

		[Required]
		[JsonProperty]
		public string Name { get; private set; }

		[Required]
		[JsonProperty]
		public string Rank { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cb0c2f6b9700dc2d76f896c171e5badb</Hash>
</Codenesium>*/