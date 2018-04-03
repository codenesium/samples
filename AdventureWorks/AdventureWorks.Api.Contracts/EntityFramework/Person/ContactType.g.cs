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
		public int contactTypeID {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>3f7a35b94cdcb57b209bb05bcbd015e7</Hash>
</Codenesium>*/