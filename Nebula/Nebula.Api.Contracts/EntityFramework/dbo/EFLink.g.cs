using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace NebulaNS.Api.Contracts
{
	[Table("Link", Schema="dbo")]
	public partial class EFLink
	{
		public EFLink()
		{}

		public void SetProperties(int id,
		                          string name,
		                          string dynamicParameters,
		                          string staticParameters,
		                          int chainId,
		                          Nullable<int> assignedMachineId,
		                          int linkStatusId,
		                          int order,
		                          Nullable<DateTime> dateStarted,
		                          Nullable<DateTime> dateCompleted,
		                          string response,
		                          Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.DynamicParameters = dynamicParameters;
			this.StaticParameters = staticParameters;
			this.ChainId = chainId.ToInt();
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Order = order.ToInt();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.Response = response;
			this.ExternalId = externalId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="varchar(128)")]
		public string Name {get; set;}

		[Column("dynamicParameters", TypeName="text(2147483647)")]
		public string DynamicParameters {get; set;}

		[Column("staticParameters", TypeName="text(2147483647)")]
		public string StaticParameters {get; set;}

		[Column("chainId", TypeName="int")]
		public int ChainId {get; set;}

		[Column("assignedMachineId", TypeName="int")]
		public Nullable<int> AssignedMachineId {get; set;}

		[Column("linkStatusId", TypeName="int")]
		public int LinkStatusId {get; set;}

		[Column("order", TypeName="int")]
		public int Order {get; set;}

		[Column("dateStarted", TypeName="datetime")]
		public Nullable<DateTime> DateStarted {get; set;}

		[Column("dateCompleted", TypeName="datetime")]
		public Nullable<DateTime> DateCompleted {get; set;}

		[Column("response", TypeName="text(2147483647)")]
		public string Response {get; set;}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId {get; set;}

		public virtual EFChain Chain { get; set; }

		public virtual EFMachine Machine { get; set; }

		public virtual EFLinkStatus LinkStatus { get; set; }
	}
}

/*<Codenesium>
    <Hash>c5c935f143b7b1d5c6e4b56c84868f96</Hash>
</Codenesium>*/