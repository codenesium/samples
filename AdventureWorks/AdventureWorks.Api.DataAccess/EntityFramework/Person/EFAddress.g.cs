using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Address", Schema="Person")]
	public partial class EFAddress: AbstractEntityFrameworkPOCO
	{
		public EFAddress()
		{}

		public void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			int stateProvinceID,
			string postalCode,
			object spatialLocation,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1.ToString();
			this.AddressLine2 = addressLine2.ToString();
			this.City = city.ToString();
			this.StateProvinceID = stateProvinceID.ToInt();
			this.PostalCode = postalCode.ToString();
			this.SpatialLocation = spatialLocation;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("AddressID", TypeName="int")]
		public int AddressID { get; set; }

		[Column("AddressLine1", TypeName="nvarchar(60)")]
		public string AddressLine1 { get; set; }

		[Column("AddressLine2", TypeName="nvarchar(60)")]
		public string AddressLine2 { get; set; }

		[Column("City", TypeName="nvarchar(30)")]
		public string City { get; set; }

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; set; }

		[Column("PostalCode", TypeName="nvarchar(15)")]
		public string PostalCode { get; set; }

		[Column("SpatialLocation", TypeName="geography(-1)")]
		public object SpatialLocation { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("StateProvinceID")]
		public virtual EFStateProvince StateProvince { get; set; }
	}
}

/*<Codenesium>
    <Hash>fb99c1861faaa44c3538b1a747b73513</Hash>
</Codenesium>*/