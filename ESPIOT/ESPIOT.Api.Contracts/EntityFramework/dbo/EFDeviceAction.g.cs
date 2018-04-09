using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class EFDeviceAction
	{
		public EFDeviceAction()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("deviceId", TypeName="int")]
		public int DeviceId {get; set;}

		[Column("name", TypeName="varchar(90)")]
		public string Name {get; set;}

		[Column("value", TypeName="varchar(4000)")]
		public string @Value {get; set;}

		public virtual EFDevice Device { get; set; }
	}
}

/*<Codenesium>
    <Hash>f0b0ddeaf246ebd857c2397240a65f42</Hash>
</Codenesium>*/