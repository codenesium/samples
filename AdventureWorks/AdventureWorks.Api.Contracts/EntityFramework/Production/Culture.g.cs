using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Culture", Schema="Production")]
	public partial class EFCulture
	{
		public EFCulture()
		{}

		[Key]
		public string cultureID {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>7b5c153d7e9062981fdab97caf02771e</Hash>
</Codenesium>*/