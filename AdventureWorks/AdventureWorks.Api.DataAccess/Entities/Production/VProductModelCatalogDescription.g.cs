using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vProductModelCatalogDescription", Schema="Production")]
	public partial class VProductModelCatalogDescription : AbstractEntity
	{
		public VProductModelCatalogDescription()
		{
		}

		public virtual void SetProperties(
			string bikeFrame,
			string color,
			string copyright,
			string crankset,
			string maintenanceDescription,
			string manufacturer,
			string material,
			DateTime modifiedDate,
			string name,
			string noOfYear,
			string pedal,
			string pictureAngle,
			string pictureSize,
			string productLine,
			int productModelID,
			string productPhotoID,
			string productURL,
			string riderExperience,
			Guid rowguid,
			string saddle,
			string style,
			string summary,
			string warrantyDescription,
			string warrantyPeriod,
			string wheel)
		{
			this.BikeFrame = bikeFrame;
			this.Color = color;
			this.Copyright = copyright;
			this.Crankset = crankset;
			this.MaintenanceDescription = maintenanceDescription;
			this.Manufacturer = manufacturer;
			this.Material = material;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.NoOfYear = noOfYear;
			this.Pedal = pedal;
			this.PictureAngle = pictureAngle;
			this.PictureSize = pictureSize;
			this.ProductLine = productLine;
			this.ProductModelID = productModelID;
			this.ProductPhotoID = productPhotoID;
			this.ProductURL = productURL;
			this.RiderExperience = riderExperience;
			this.Rowguid = rowguid;
			this.Saddle = saddle;
			this.Style = style;
			this.Summary = summary;
			this.WarrantyDescription = warrantyDescription;
			this.WarrantyPeriod = warrantyPeriod;
			this.Wheel = wheel;
		}

		[Column("BikeFrame")]
		public string BikeFrame { get; private set; }

		[MaxLength(256)]
		[Column("Color")]
		public string Color { get; private set; }

		[MaxLength(30)]
		[Column("Copyright")]
		public string Copyright { get; private set; }

		[MaxLength(256)]
		[Column("Crankset")]
		public string Crankset { get; private set; }

		[MaxLength(256)]
		[Column("MaintenanceDescription")]
		public string MaintenanceDescription { get; private set; }

		[Column("Manufacturer")]
		public string Manufacturer { get; private set; }

		[MaxLength(256)]
		[Column("Material")]
		public string Material { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(256)]
		[Column("NoOfYears")]
		public string NoOfYear { get; private set; }

		[MaxLength(256)]
		[Column("Pedal")]
		public string Pedal { get; private set; }

		[MaxLength(256)]
		[Column("PictureAngle")]
		public string PictureAngle { get; private set; }

		[MaxLength(256)]
		[Column("PictureSize")]
		public string PictureSize { get; private set; }

		[MaxLength(256)]
		[Column("ProductLine")]
		public string ProductLine { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("ProductModelID")]
		public int ProductModelID { get; private set; }

		[MaxLength(256)]
		[Column("ProductPhotoID")]
		public string ProductPhotoID { get; private set; }

		[MaxLength(256)]
		[Column("ProductURL")]
		public string ProductURL { get; private set; }

		[MaxLength(1024)]
		[Column("RiderExperience")]
		public string RiderExperience { get; private set; }

		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[MaxLength(256)]
		[Column("Saddle")]
		public string Saddle { get; private set; }

		[MaxLength(256)]
		[Column("Style")]
		public string Style { get; private set; }

		[Column("Summary")]
		public string Summary { get; private set; }

		[MaxLength(256)]
		[Column("WarrantyDescription")]
		public string WarrantyDescription { get; private set; }

		[MaxLength(256)]
		[Column("WarrantyPeriod")]
		public string WarrantyPeriod { get; private set; }

		[MaxLength(256)]
		[Column("Wheel")]
		public string Wheel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6deb091553783cd1a252358225915ee7</Hash>
</Codenesium>*/