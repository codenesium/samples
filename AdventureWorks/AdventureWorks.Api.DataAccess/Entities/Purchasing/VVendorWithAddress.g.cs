using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vVendorWithAddresses", Schema="Purchasing")]
	public partial class VVendorWithAddress : AbstractEntity
	{
		public VVendorWithAddress()
		{
		}

		public virtual void SetProperties(
			string addressLine1,
			string addressLine2,
			string addressType,
			int businessEntityID,
			string city,
			string countryRegionName,
			string name,
			string postalCode,
			string stateProvinceName)
		{
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.AddressType = addressType;
			this.BusinessEntityID = businessEntityID;
			this.City = city;
			this.CountryRegionName = countryRegionName;
			this.Name = name;
			this.PostalCode = postalCode;
			this.StateProvinceName = stateProvinceName;
		}

		[MaxLength(60)]
		[Column("AddressLine1")]
		public virtual string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public virtual string AddressLine2 { get; private set; }

		[MaxLength(50)]
		[Column("AddressType")]
		public virtual string AddressType { get; private set; }

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public virtual string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegionName")]
		public virtual string CountryRegionName { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public virtual string PostalCode { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public virtual string StateProvinceName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>b784ac6e79c9aec062d0486d1e5bc4e3</Hash>
</Codenesium>*/