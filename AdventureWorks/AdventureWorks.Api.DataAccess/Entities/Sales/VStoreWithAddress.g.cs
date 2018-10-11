using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vStoreWithAddresses", Schema="Sales")]
	public partial class VStoreWithAddress : AbstractEntity
	{
		public VStoreWithAddress()
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
		public string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public string AddressLine2 { get; private set; }

		[MaxLength(50)]
		[Column("AddressType")]
		public string AddressType { get; private set; }

		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public string City { get; private set; }

		[MaxLength(50)]
		[Column("CountryRegionName")]
		public string CountryRegionName { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public string PostalCode { get; private set; }

		[MaxLength(50)]
		[Column("StateProvinceName")]
		public string StateProvinceName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>576d738b83b3b1d41afdcf6c2ef89aac</Hash>
</Codenesium>*/