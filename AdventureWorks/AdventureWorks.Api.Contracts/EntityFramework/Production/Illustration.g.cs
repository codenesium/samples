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
		public int illustrationID {get; set;}
		public string diagram {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>e57adc84e8f847a1ff245f3b482b2cde</Hash>
</Codenesium>*/