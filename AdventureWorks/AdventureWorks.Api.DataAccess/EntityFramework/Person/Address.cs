using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Address", Schema="Person")]
	public partial class Address: AbstractEntityFrameworkPOCO
	{
		public Address()
		{}

		public void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			object spatialLocation,
			int stateProvinceID)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1.ToString();
			this.AddressLine2 = addressLine2.ToString();
			this.City = city.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PostalCode = postalCode.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.SpatialLocation = spatialLocation;
			this.StateProvinceID = stateProvinceID.ToInt();
		}

		[Key]
		[Column("AddressID", TypeName="int")]
		public int AddressID { get; set; }

		[Column("AddressLine1", TypeName="nvarchar(60)")]
		public string AddressLine1 { get; set; }

		[Column("AddressLine2", TypeName="nvarchar(60)")]
		public string AddressLine2 { get; set; }

		[Column("City", TypeName="nvarchar(30)")]
		public string City { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PostalCode", TypeName="nvarchar(15)")]
		public string PostalCode { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("SpatialLocation", TypeName="geography(-1)")]
		public object SpatialLocation { get; set; }

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; set; }
	}
}

/*<Codenesium>
    <Hash>9f5fd91e1d77316eda8c0aa2d9f4818b</Hash>
</Codenesium>*/