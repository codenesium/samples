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
		public int AddressTypeID {get; set;}
		public string Name {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>da85f5549d46e7e9655866425c1b6678</Hash>
</Codenesium>*/