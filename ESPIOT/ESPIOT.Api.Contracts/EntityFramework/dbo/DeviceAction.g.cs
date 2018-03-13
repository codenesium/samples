using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ESPIOTNS.Api.Contracts
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class DeviceAction
	{
		public DeviceAction()
		{}

		public int deviceId {get; set;}
		[Key]
		public int id {get; set;}
		public string name {get; set;}
		public string @value {get; set;}

		[ForeignKey("deviceId")]
		public virtual Device DeviceRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>b028adf49dc69d645745271f22dc94d7</Hash>
</Codenesium>*/