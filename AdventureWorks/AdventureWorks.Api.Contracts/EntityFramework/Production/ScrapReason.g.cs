using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("ScrapReason", Schema="Production")]
	public partial class EFScrapReason
	{
		public EFScrapReason()
		{}

		[Key]
		public short scrapReasonID {get; set;}
		public string name {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>d78cb4d98f2de7fcf21456ad03afb206</Hash>
</Codenesium>*/