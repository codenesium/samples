using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace NebulaNS.Api.DataAccess
{
	[Table("Link", Schema="dbo")]
	public partial class EFLink:AbstractEntityFrameworkPOCO
	{
		public EFLink()
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
			this.DynamicParameters = dynamicParameters.ToString();
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Name = name.ToString();
			this.Order = order.ToInt();
			this.Response = response.ToString();
			this.StaticParameters = staticParameters.ToString();
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
		public virtual EFMachine Machine { get; set; }

		[ForeignKey("ChainId")]
		public virtual EFChain Chain { get; set; }

		[ForeignKey("LinkStatusId")]
		public virtual EFLinkStatus LinkStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>e9ea9ae3958427f297f3191a1ad47d7e</Hash>
</Codenesium>*/