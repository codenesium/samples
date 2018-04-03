using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Customer", Schema="Sales")]
	public partial class EFCustomer
	{
		public EFCustomer()
		{}

		[Key]
		public int customerID {get; set;}
		public Nullable<int> personID {get; set;}
		public Nullable<int> storeID {get; set;}
		public Nullable<int> territoryID {get; set;}
		public string accountNumber {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>dbe1094e07eb67602508dd86eeb696f0</Hash>
</Codenesium>*/