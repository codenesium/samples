using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Illustration", Schema="Production")]
	public partial class EFIllustration
	{
		public EFIllustration()
		{}

		[Key]
		public int IllustrationID {get; set;}
		public string Diagram {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>2e22b1fcdfb2d8e41012c0df1aba062c</Hash>
</Codenesium>*/