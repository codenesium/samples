using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("VehicleCapabilities", Schema="dbo")]
	public partial class VehicleCapabilitty : AbstractEntity
	{
		public VehicleCapabilitty()
		{
		}

		public virtual void SetProperties(
			int vehicleId,
			int vehicleCapabilityId)
		{
			this.VehicleId = vehicleId;
			this.VehicleCapabilityId = vehicleCapabilityId;
		}

		[Key]
		[Column("vehicleCapabilityId")]
		public virtual int VehicleCapabilityId { get; private set; }

		[Key]
		[Column("vehicleId")]
		public virtual int VehicleId { get; private set; }

		[ForeignKey("VehicleId")]
		public virtual Vehicle VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(Vehicle item)
		{
			this.VehicleIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>ba236e453c55ad235a3296c71536a6e0</Hash>
</Codenesium>*/