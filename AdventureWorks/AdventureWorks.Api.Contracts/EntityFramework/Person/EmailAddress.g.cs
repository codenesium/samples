using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("EmailAddress", Schema="Person")]
	public partial class EFEmailAddress
	{
		public EFEmailAddress()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public int emailAddressID {get; set;}
		public string emailAddress {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>cef0c5966249c546506fde2c4970e04a</Hash>
</Codenesium>*/