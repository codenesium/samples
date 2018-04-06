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

		[ForeignKey("DeviceId")]
		public virtual EFDevice DeviceRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>ce4fb8e9e95796cce28551582a2094ee</Hash>
</Codenesium>*/