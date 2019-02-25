using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("BusinessEntityAddress", Schema="Person")]
	public partial class BusinessEntityAddress : AbstractEntity
	{
		public BusinessEntityAddress()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			int addressID,
			int addressTypeID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.BusinessEntityID = businessEntityID;
			this.AddressID = addressID;
			this.AddressTypeID = addressTypeID;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
		}

		[Key]
		[Column("AddressID")]
		public virtual int AddressID { get; private set; }

		[Key]
		[Column("AddressTypeID")]
		public virtual int AddressTypeID { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[ForeignKey("AddressID")]
		public virtual Address AddressIDNavigation { get; private set; }

		public void SetAddressIDNavigation(Address item)
		{
			this.AddressIDNavigation = item;
		}

		[ForeignKey("AddressTypeID")]
		public virtual AddressType AddressTypeIDNavigation { get; private set; }

		public void SetAddressTypeIDNavigation(AddressType item)
		{
			this.AddressTypeIDNavigation = item;
		}

		[ForeignKey("BusinessEntityID")]
		public virtual BusinessEntity BusinessEntityIDNavigation { get; private set; }

		public void SetBusinessEntityIDNavigation(BusinessEntity item)
		{
			this.BusinessEntityIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f43685047e9332a0a5afc0f08b1cc2df</Hash>
</Codenesium>*/