using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Address", Schema="Person")]
	public partial class Address : AbstractEntity
	{
		public Address()
		{
		}

		public virtual void SetProperties(
			int addressID,
			string addressLine1,
			string addressLine2,
			string city,
			DateTime modifiedDate,
			string postalCode,
			Guid rowguid,
			int stateProvinceID)
		{
			this.AddressID = addressID;
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate;
			this.PostalCode = postalCode;
			this.Rowguid = rowguid;
			this.StateProvinceID = stateProvinceID;
		}

		[Key]
		[Column("AddressID")]
		public int AddressID { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine1")]
		public string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public string AddressLine2 { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public string City { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public string PostalCode { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("StateProvinceID")]
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>47e954ff2c5857f6d05ca3a46982bcda</Hash>
</Codenesium>*/