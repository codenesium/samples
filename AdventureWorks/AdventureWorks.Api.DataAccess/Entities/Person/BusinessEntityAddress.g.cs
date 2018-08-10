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

		[Column("AddressID")]
		public int AddressID { get; private set; }

		[Column("AddressTypeID")]
		public int AddressTypeID { get; private set; }

		[Key]
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ae22d0b2bf8247933d11d190edf07a6b</Hash>
</Codenesium>*/