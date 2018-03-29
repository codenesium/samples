using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ContactType", Schema="Person")]
	public partial class EFContactType
	{
		public EFContactType()
		{}

		[Key]
		public int ContactTypeID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>abc2024cbf688e8b449a60aecddee2d4</Hash>
</Codenesium>*/