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
		public string CultureID {get; set;}
		public string Name {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>37cb1d57f72339dee6f6706f93977f3f</Hash>
</Codenesium>*/