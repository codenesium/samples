using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Store", Schema="Sales")]
	public partial class EFStore
	{
		public EFStore()
		{}

		[Key]
		public int businessEntityID {get; set;}
		public string name {get; set;}
		public Nullable<int> salesPersonID {get; set;}
		public string demographics {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>ec9af8a3ae81f96676c2f6eb7af3c716</Hash>
</Codenesium>*/