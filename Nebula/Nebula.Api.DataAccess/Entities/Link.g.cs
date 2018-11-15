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
			string dynamicParameter,
			Guid externalId,
			int id,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameter,
			int timeoutInSecond)
		{
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameter = dynamicParameter;
			this.ExternalId = externalId;
			this.Id = id;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameter = staticParameter;
			this.TimeoutInSecond = timeoutInSecond;
		}

		[Column("assignedMachineId")]
		public virtual int? AssignedMachineId { get; private set; }

		[Column("chainId")]
		public virtual int ChainId { get; private set; }

		[Column("dateCompleted")]
		public virtual DateTime? DateCompleted { get; private set; }

		[Column("dateStarted")]
		public virtual DateTime? DateStarted { get; private set; }

		[MaxLength(2147483647)]
		[Column("dynamicParameters")]
		public virtual string DynamicParameter { get; private set; }

		[Column("externalId")]
		public virtual Guid ExternalId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("linkStatusId")]
		public virtual int LinkStatusId { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("order")]
		public virtual int Order { get; private set; }

		[MaxLength(2147483647)]
		[Column("response")]
		public virtual string Response { get; private set; }

		[MaxLength(2147483647)]
		[Column("staticParameters")]
		public virtual string StaticParameter { get; private set; }

		[Column("timeoutInSeconds")]
		public virtual int TimeoutInSecond { get; private set; }

		[ForeignKey("AssignedMachineId")]
		public virtual Machine MachineNavigation { get; private set; }

		public void SetMachineNavigation(Machine item)
		{
			this.MachineNavigation = item;
		}

		[ForeignKey("LinkStatusId")]
		public virtual LinkStatus LinkStatusNavigation { get; private set; }

		public void SetLinkStatusNavigation(LinkStatus item)
		{
			this.LinkStatusNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>75147ada0275d12d97f114cd390f1d0d</Hash>
</Codenesium>*/