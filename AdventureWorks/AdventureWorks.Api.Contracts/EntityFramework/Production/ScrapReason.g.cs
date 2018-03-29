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
		public short ScrapReasonID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>43428414edd6cc3a6a23c8d5f8261fdb</Hash>
</Codenesium>*/