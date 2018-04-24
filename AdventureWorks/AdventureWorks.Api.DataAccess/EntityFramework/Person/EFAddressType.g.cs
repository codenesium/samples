using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("AddressType", Schema="Person")]
	public partial class EFAddressType: AbstractEntityFrameworkPOCO
	{
		public EFAddressType()
		{}

		public void SetProperties(
			int addressTypeID,
			string name,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.AddressTypeID = addressTypeID.ToInt();
			this.Name = name.ToString();
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("AddressTypeID", TypeName="int")]
		public int AddressTypeID { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>e8f87f90de5de2fca32b1205c38a7103</Hash>
</Codenesium>*/