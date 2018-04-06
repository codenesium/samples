using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BusinessEntityAddress", Schema="Person")]
	public partial class EFBusinessEntityAddress
	{
		public EFBusinessEntityAddress()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}
		[Column("AddressID", TypeName="int")]
		public int AddressID {get; set;}
		[Column("AddressTypeID", TypeName="int")]
		public int AddressTypeID {get; set;}
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}
		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
		[ForeignKey("AddressID")]
		public virtual EFAddress AddressRef { get; set; }
		[ForeignKey("AddressTypeID")]
		public virtual EFAddressType AddressTypeRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>59a8e221d1a3ea765075e0439a5f1512</Hash>
</Codenesium>*/