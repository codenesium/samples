using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class DeviceAction: AbstractEntityFrameworkPOCO
	{
		public DeviceAction()
		{}

		public void SetProperties(
			int id,
			int deviceId,
			string name,
			string @value)
		{
			this.DeviceId = deviceId.ToInt();
			this.Id = id.ToInt();
			this.Name = name;
			this.@Value = @value;
		}

		[Column("deviceId", TypeName="int")]
		public int DeviceId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(90)")]
		public string Name { get; set; }

		[Column("value", TypeName="varchar(4000)")]
		public string @Value { get; set; }

		[ForeignKey("DeviceId")]
		public virtual Device Device { get; set; }
	}
}

/*<Codenesium>
    <Hash>d9066ca7365116637c5f4ff3222e2356</Hash>
</Codenesium>*/