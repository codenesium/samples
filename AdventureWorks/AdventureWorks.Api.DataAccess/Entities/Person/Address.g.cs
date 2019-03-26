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
		public virtual int AddressID { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine1")]
		public virtual string AddressLine1 { get; private set; }

		[MaxLength(60)]
		[Column("AddressLine2")]
		public virtual string AddressLine2 { get; private set; }

		[MaxLength(30)]
		[Column("City")]
		public virtual string City { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(15)]
		[Column("PostalCode")]
		public virtual string PostalCode { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("StateProvinceID")]
		public virtual int StateProvinceID { get; private set; }

		[ForeignKey("StateProvinceID")]
		public virtual StateProvince StateProvinceIDNavigation { get; private set; }

		public void SetStateProvinceIDNavigation(StateProvince item)
		{
			this.StateProvinceIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>7987a903d9769ce2f076e9d5c9380ee5</Hash>
</Codenesium>*/