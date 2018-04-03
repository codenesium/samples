using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("BusinessEntityAddress", Schema="Person")]
	public partial class EFBusinessEntityAddress
	{
		public EFBusinessEntityAddress()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public int addressID {get; set;}
		public int addressTypeID {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>8f550a5c8483c8ea082a7c01383c19d3</Hash>
</Codenesium>*/