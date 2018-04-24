using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityAddress", Schema="Person")]
	public partial class EFBusinessEntityAddress: AbstractEntityFrameworkPOCO
	{
		public EFBusinessEntityAddress()
		{}

		public void SetProperties(
			int businessEntityID,
			int addressID,
			int addressTypeID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.AddressID = addressID.ToInt();
			this.AddressTypeID = addressTypeID.ToInt();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("AddressID", TypeName="int")]
		public int AddressID { get; set; }

		[Column("AddressTypeID", TypeName="int")]
		public int AddressTypeID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntity { get; set; }

		[ForeignKey("AddressID")]
		public virtual EFAddress Address { get; set; }

		[ForeignKey("AddressTypeID")]
		public virtual EFAddressType AddressType { get; set; }
	}
}

/*<Codenesium>
    <Hash>368ed99369f73bdbe87136c28ba97e6a</Hash>
</Codenesium>*/