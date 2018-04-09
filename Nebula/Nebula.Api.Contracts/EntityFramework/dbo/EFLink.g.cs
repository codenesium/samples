using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NebulaNS.Api.Contracts
{
	[Table("Link", Schema="dbo")]
	public partial class EFLink
	{
		public EFLink()
		{}

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
    <Hash>d59f0c5a34c29f783eedc3e4a93cac0a</Hash>
</Codenesium>*/