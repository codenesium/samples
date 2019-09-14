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
			int id,
			int? assignedMachineId,
			int chainId,
			DateTime? dateCompleted,
			DateTime? dateStarted,
			string dynamicParameters,
			Guid externalId,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameters,
			int timeoutInSeconds)
		{
			this.Id = id;
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds;
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
		public virtual string DynamicParameters { get; private set; }

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
		public virtual string StaticParameters { get; private set; }

		[Column("timeoutInSeconds")]
		public virtual int TimeoutInSeconds { get; private set; }

		[ForeignKey("AssignedMachineId")]
		public virtual Machine AssignedMachineIdNavigation { get; private set; }

		public void SetAssignedMachineIdNavigation(Machine item)
		{
			this.AssignedMachineIdNavigation = item;
		}

		[ForeignKey("ChainId")]
		public virtual Chain ChainIdNavigation { get; private set; }

		public void SetChainIdNavigation(Chain item)
		{
			this.ChainIdNavigation = item;
		}

		[ForeignKey("LinkStatusId")]
		public virtual LinkStatus LinkStatusIdNavigation { get; private set; }

		public void SetLinkStatusIdNavigation(LinkStatus item)
		{
			this.LinkStatusIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>710e1df6b0be02f83d4a3fcc0d9a8ee9</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/