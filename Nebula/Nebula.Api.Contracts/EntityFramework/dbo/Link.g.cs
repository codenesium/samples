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
		public int id {get; set;}
		public string name {get; set;}
		public string dynamicParameters {get; set;}
		public string staticParameters {get; set;}
		public int chainId {get; set;}
		public Nullable<int> assignedMachineId {get; set;}
		public int linkStatusId {get; set;}
		public int order {get; set;}
		public Nullable<DateTime> dateStarted {get; set;}
		public Nullable<DateTime> dateCompleted {get; set;}
		public string response {get; set;}
		public Guid externalId {get; set;}

		[ForeignKey("chainId")]
		public virtual EFChain ChainRef { get; set; }
		[ForeignKey("assignedMachineId")]
		public virtual EFMachine MachineRef { get; set; }
		[ForeignKey("linkStatusId")]
		public virtual EFLinkStatus LinkStatusRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>dd521bf17b8f9381e9daf04fcb02e1e8</Hash>
</Codenesium>*/