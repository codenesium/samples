using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AddressType", Schema="Person")]
	public partial class AddressType : AbstractEntity
	{
		public AddressType()
		{
		}

		public virtual void SetProperties(
			int addressTypeID,
			DateTime modifiedDate,
			string name,
			Guid rowguid)
		{
			this.AddressTypeID = addressTypeID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
		}

		[Key]
		[Column("AddressTypeID")]
		public virtual int AddressTypeID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>6cb33946a5ce21f10bd5243380ecf9b0</Hash>
</Codenesium>*/