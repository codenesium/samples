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
		public int BusinessEntityID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>02c838ecbe8f707db32ff3bff1425f98</Hash>
</Codenesium>*/