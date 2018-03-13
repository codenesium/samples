using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("Device", Schema="dbo")]
	public partial class Device
	{
		public Device()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public Guid publicId {get; set;}
	}
}

/*<Codenesium>
    <Hash>01991f5f1fb733214182c8a0fc928e3b</Hash>
</Codenesium>*/