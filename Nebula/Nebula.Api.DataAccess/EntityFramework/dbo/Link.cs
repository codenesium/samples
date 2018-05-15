using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Link", Schema="dbo")]
	public partial class Link:AbstractEntityFrameworkPOCO
	{
		public Link()
		{}

		public void SetProperties(
			int id,
			Nullable<int> assignedMachineId,
			int chainId,
			Nullable<DateTime> dateCompleted,
			Nullable<DateTime> dateStarted,
			string dynamicParameters,
			Guid externalId,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameters,
			int timeoutInSeconds)
		{
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.ChainId = chainId.ToInt();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds.ToInt();
		}

		[Column("assignedMachineId", TypeName="int")]
		public Nullable<int> AssignedMachineId { get; set; }

		[Column("chainId", TypeName="int")]
		public int ChainId { get; set; }

		[Column("dateCompleted", TypeName="datetime")]
		public Nullable<DateTime> DateCompleted { get; set; }

		[Column("dateStarted", TypeName="datetime")]
		public Nullable<DateTime> DateStarted { get; set; }

		[Column("dynamicParameters", TypeName="text(2147483647)")]
		public string DynamicParameters { get; set; }

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("linkStatusId", TypeName="int")]
		public int LinkStatusId { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }

		[Column("order", TypeName="int")]
		public int Order { get; set; }

		[Column("response", TypeName="text(2147483647)")]
		public string Response { get; set; }

		[Column("staticParameters", TypeName="text(2147483647)")]
		public string StaticParameters { get; set; }

		[Column("timeoutInSeconds", TypeName="int")]
		public int TimeoutInSeconds { get; set; }

		[ForeignKey("AssignedMachineId")]
		public virtual Machine Machine { get; set; }

		[ForeignKey("ChainId")]
		public virtual Chain Chain { get; set; }

		[ForeignKey("LinkStatusId")]
		public virtual LinkStatus LinkStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>306218b54d454b251d30e93a0f5a58f8</Hash>
</Codenesium>*/