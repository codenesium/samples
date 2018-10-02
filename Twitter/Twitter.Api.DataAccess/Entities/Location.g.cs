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
		public int GpsLat { get; private set; }

		[Column("gps_long")]
		public int GpsLong { get; private set; }

		[Key]
		[Column("location_id")]
		public int LocationId { get; private set; }

		[MaxLength(64)]
		[Column("location_name")]
		public string LocationName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9e4c381cf4460e5469e5491f27322eac</Hash>
</Codenesium>*/