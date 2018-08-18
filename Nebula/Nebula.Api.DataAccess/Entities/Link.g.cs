using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace NebulaNS.Api.DataAccess
{
	[Table("Link", Schema="dbo")]
	public partial class Link : AbstractEntity
	{
		public Link()
		{
		}

		public virtual void SetProperties(
			int? assignedMachineId,
			int chainId,
			DateTime? dateCompleted,
			DateTime? dateStarted,
			string dynamicParameters,
			Guid externalId,
			int id,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameters,
			int timeoutInSeconds)
		{
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.Id = id;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds;
		}

		[Column("assignedMachineId")]
		public int? AssignedMachineId { get; private set; }

		[Column("chainId")]
		public int ChainId { get; private set; }

		[Column("dateCompleted")]
		public DateTime? DateCompleted { get; private set; }

		[Column("dateStarted")]
		public DateTime? DateStarted { get; private set; }

		[MaxLength(2147483647)]
		[Column("dynamicParameters")]
		public string DynamicParameters { get; private set; }

		[Column("externalId")]
		public Guid ExternalId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("linkStatusId")]
		public int LinkStatusId { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("order")]
		public int Order { get; private set; }

		[MaxLength(2147483647)]
		[Column("response")]
		public string Response { get; private set; }

		[MaxLength(2147483647)]
		[Column("staticParameters")]
		public string StaticParameters { get; private set; }

		[Column("timeoutInSeconds")]
		public int TimeoutInSeconds { get; private set; }

		[ForeignKey("AssignedMachineId")]
		public virtual Machine MachineNavigation { get; private set; }

		[ForeignKey("ChainId")]
		public virtual Chain ChainNavigation { get; private set; }

		[ForeignKey("LinkStatusId")]
		public virtual LinkStatus LinkStatusNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5df79e87ece6f0ad01c51ab8dd8a0591</Hash>
</Codenesium>*/