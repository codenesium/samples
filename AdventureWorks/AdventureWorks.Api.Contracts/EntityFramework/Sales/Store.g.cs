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
		public int BusinessEntityID {get; set;}
		public string Name {get; set;}
		public Nullable<int> SalesPersonID {get; set;}
		public string Demographics {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
		[ForeignKey("SalesPersonID")]
		public virtual EFSalesPerson SalesPersonRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>a2b8a9192d1730570098fe1200277ae3</Hash>
</Codenesium>*/