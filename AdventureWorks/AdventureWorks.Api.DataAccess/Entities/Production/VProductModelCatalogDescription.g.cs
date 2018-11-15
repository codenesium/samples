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
		public virtual string BikeFrame { get; private set; }

		[MaxLength(256)]
		[Column("Color")]
		public virtual string Color { get; private set; }

		[MaxLength(30)]
		[Column("Copyright")]
		public virtual string Copyright { get; private set; }

		[MaxLength(256)]
		[Column("Crankset")]
		public virtual string Crankset { get; private set; }

		[MaxLength(256)]
		[Column("MaintenanceDescription")]
		public virtual string MaintenanceDescription { get; private set; }

		[Column("Manufacturer")]
		public virtual string Manufacturer { get; private set; }

		[MaxLength(256)]
		[Column("Material")]
		public virtual string Material { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[MaxLength(256)]
		[Column("NoOfYears")]
		public virtual string NoOfYear { get; private set; }

		[MaxLength(256)]
		[Column("Pedal")]
		public virtual string Pedal { get; private set; }

		[MaxLength(256)]
		[Column("PictureAngle")]
		public virtual string PictureAngle { get; private set; }

		[MaxLength(256)]
		[Column("PictureSize")]
		public virtual string PictureSize { get; private set; }

		[MaxLength(256)]
		[Column("ProductLine")]
		public virtual string ProductLine { get; private set; }

		[Column("ProductModelID")]
		public virtual int ProductModelID { get; private set; }

		[MaxLength(256)]
		[Column("ProductPhotoID")]
		public virtual string ProductPhotoID { get; private set; }

		[MaxLength(256)]
		[Column("ProductURL")]
		public virtual string ProductURL { get; private set; }

		[MaxLength(1024)]
		[Column("RiderExperience")]
		public virtual string RiderExperience { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[MaxLength(256)]
		[Column("Saddle")]
		public virtual string Saddle { get; private set; }

		[MaxLength(256)]
		[Column("Style")]
		public virtual string Style { get; private set; }

		[Column("Summary")]
		public virtual string Summary { get; private set; }

		[MaxLength(256)]
		[Column("WarrantyDescription")]
		public virtual string WarrantyDescription { get; private set; }

		[MaxLength(256)]
		[Column("WarrantyPeriod")]
		public virtual string WarrantyPeriod { get; private set; }

		[MaxLength(256)]
		[Column("Wheel")]
		public virtual string Wheel { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6ac68e69030d57ecebb33c4196da7984</Hash>
</Codenesium>*/