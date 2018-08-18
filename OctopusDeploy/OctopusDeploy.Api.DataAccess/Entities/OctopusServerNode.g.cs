using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("OctopusServerNode", Schema="dbo")]
	public partial class OctopusServerNode : AbstractEntity
	{
		public OctopusServerNode()
		{
		}

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

		[Key]
		[MaxLength(250)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("IsInMaintenanceMode")]
		public bool IsInMaintenanceMode { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[Column("LastSeen")]
		public DateTimeOffset LastSeen { get; private set; }

		[Column("MaxConcurrentTasks")]
		public int MaxConcurrentTasks { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("Rank")]
		public string Rank { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f1ae9ccc6e54f7945557a62f79d337d1</Hash>
</Codenesium>*/