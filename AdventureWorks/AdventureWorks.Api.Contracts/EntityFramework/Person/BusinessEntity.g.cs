using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BusinessEntity", Schema="Person")]
	public partial class EFBusinessEntity
	{
		public EFBusinessEntity()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>8aa93949db1ea86d54b2505f16813ef6</Hash>
</Codenesium>*/