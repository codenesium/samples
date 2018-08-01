using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("DeviceAction", Schema="dbo")]
	public partial class DeviceAction : AbstractEntity
	{
		public DeviceAction()
		{
		}

		public virtual void SetProperties(
			int deviceId,
			int id,
			string name,
			string @value)
		{
			this.DeviceId = deviceId;
			this.Id = id;
			this.Name = name;
			this.@Value = @value;
		}

		[Column("deviceId")]
		public int DeviceId { get; private set; }

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }

		[Column("value")]
		public string @Value { get; private set; }

		[ForeignKey("DeviceId")]
		public virtual Device DeviceNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>dc21c1298a8bdeca7333d9015ce7d8e4</Hash>
</Codenesium>*/