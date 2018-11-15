using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterNS.Api.DataAccess
{
	[Table("Location", Schema="dbo")]
	public partial class Location : AbstractEntity
	{
		public Location()
		{
		}

		public virtual void SetProperties(
			int gpsLat,
			int gpsLong,
			int locationId,
			string locationName)
		{
			this.GpsLat = gpsLat;
			this.GpsLong = gpsLong;
			this.LocationId = locationId;
			this.LocationName = locationName;
		}

		[Column("gps_lat")]
		public virtual int GpsLat { get; private set; }

		[Column("gps_long")]
		public virtual int GpsLong { get; private set; }

		[Key]
		[Column("location_id")]
		public virtual int LocationId { get; private set; }

		[MaxLength(64)]
		[Column("location_name")]
		public virtual string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e9178c72e6ed483ac235abe35c5d7929</Hash>
</Codenesium>*/