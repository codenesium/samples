using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OctopusDeployNS.Api.DataAccess
{
	[Table("WorkerTaskLease", Schema="dbo")]
	public partial class WorkerTaskLease : AbstractEntity
	{
		public WorkerTaskLease()
		{
		}

		public virtual void SetProperties(
			bool exclusive,
			string id,
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

		[Column("Exclusive")]
		public bool Exclusive { get; private set; }

		[Key]
		[MaxLength(50)]
		[Column("Id")]
		public string Id { get; private set; }

		[Column("JSON")]
		public string JSON { get; private set; }

		[MaxLength(200)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("TaskId")]
		public string TaskId { get; private set; }

		[MaxLength(50)]
		[Column("WorkerId")]
		public string WorkerId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>1cff6e3d6ad1479f9c04159ac7af9f6f</Hash>
</Codenesium>*/