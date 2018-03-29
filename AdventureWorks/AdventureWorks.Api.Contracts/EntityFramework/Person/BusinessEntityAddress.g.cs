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
		public int BusinessEntityID {get; set;}
		public int AddressID {get; set;}
		public int AddressTypeID {get; set;}
		public Guid rowguid {get; set;}
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
    <Hash>c0cc8572d390fe0a3fb1e9e96b3905f2</Hash>
</Codenesium>*/