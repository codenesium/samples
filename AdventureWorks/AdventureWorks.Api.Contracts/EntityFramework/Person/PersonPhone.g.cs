using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonPhone", Schema="Person")]
	public partial class EFPersonPhone
	{
		public EFPersonPhone()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public string phoneNumber {get; set;}
		public int phoneNumberTypeID {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>20c970fd0c759b490c2dac7198e5895e</Hash>
</Codenesium>*/