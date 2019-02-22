using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("VehicleRefCapability", Schema="dbo")]
	public partial class VehicleRefCapability : AbstractEntity
	{
		public VehicleRefCapability()
		{
		}

		public virtual void SetProperties(
			int id,
			int vehicleCapabilityId,
			int vehicleId)
		{
			this.Id = id;
			this.VehicleCapabilityId = vehicleCapabilityId;
			this.VehicleId = vehicleId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("vehicleCapabilityId")]
		public virtual int VehicleCapabilityId { get; private set; }

		[Column("vehicleId")]
		public virtual int VehicleId { get; private set; }

		[ForeignKey("VehicleCapabilityId")]
		public virtual VehicleCapability VehicleCapabilityIdNavigation { get; private set; }

		public void SetVehicleCapabilityIdNavigation(VehicleCapability item)
		{
			this.VehicleCapabilityIdNavigation = item;
		}

		[ForeignKey("VehicleId")]
		public virtual Vehicle VehicleIdNavigation { get; private set; }

		public void SetVehicleIdNavigation(Vehicle item)
		{
			this.VehicleIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f693fb6f5fbeb5f82db1e3e7e9df52ac</Hash>
</Codenesium>*/