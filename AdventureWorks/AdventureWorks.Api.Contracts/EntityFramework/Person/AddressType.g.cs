using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("AddressType", Schema="Person")]
	public partial class EFAddressType
	{
		public EFAddressType()
		{}

		[Key]
		public int addressTypeID {get; set;}
		public string name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>f80c9f39e3173758b16f607fb6b40f5e</Hash>
</Codenesium>*/