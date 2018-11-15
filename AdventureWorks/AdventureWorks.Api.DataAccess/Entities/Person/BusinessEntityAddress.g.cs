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
			int addressID,
			int addressTypeID,
			int businessEntityID,
			DateTime modifiedDate,
			Guid rowguid)
		{
			this.AddressID = addressID;
			this.AddressTypeID = addressTypeID;
			this.BusinessEntityID = businessEntityID;
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
	}
}

/*<Codenesium>
    <Hash>1f965b1aa1dbdc20aeba15c5db48d6e2</Hash>
</Codenesium>*/