using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityAddress", Schema="Person")]
	public partial class BusinessEntityAddress: AbstractEntityFrameworkPOCO
	{
		public BusinessEntityAddress()
		{}

		public void SetProperties(
			int businessEntityID,
			int addressID,
			int addressTypeID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.BusinessEntityID = businessEntityID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
		}

		[Column("AddressID", TypeName="int")]
		public int AddressID { get; set; }

		[Column("AddressTypeID", TypeName="int")]
		public int AddressTypeID { get; set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }
	}
}

/*<Codenesium>
    <Hash>4490326b2deb51b57cba19c917962fbc</Hash>
</Codenesium>*/