using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Address", Schema="Person")]
	public partial class Address: AbstractEntity
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
			int stateProvinceID)
		{
			this.AddressID = addressID.ToInt();
			this.AddressLine1 = addressLine1;
			this.AddressLine2 = addressLine2;
			this.City = city;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PostalCode = postalCode;
			this.Rowguid = rowguid.ToGuid();
			this.StateProvinceID = stateProvinceID.ToInt();
		}

		[Key]
		[Column("AddressID", TypeName="int")]
		public int AddressID { get; private set; }

		[Column("AddressLine1", TypeName="nvarchar(60)")]
		public string AddressLine1 { get; private set; }

		[Column("AddressLine2", TypeName="nvarchar(60)")]
		public string AddressLine2 { get; private set; }

		[Column("City", TypeName="nvarchar(30)")]
		public string City { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PostalCode", TypeName="nvarchar(15)")]
		public string PostalCode { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("StateProvinceID", TypeName="int")]
		public int StateProvinceID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7a0b8d70e0d921454575ed2f79fcf2c7</Hash>
</Codenesium>*/