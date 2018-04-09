using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CountryRegionCurrency", Schema="Sales")]
	public partial class EFCountryRegionCurrency
	{
		public EFCountryRegionCurrency()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode {get; set;}

		[Column("CurrencyCode", TypeName="nchar(3)")]
		public string CurrencyCode {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFCountryRegion CountryRegion { get; set; }

		public virtual EFCurrency Currency { get; set; }
	}
}

/*<Codenesium>
    <Hash>405cf8e9069292beaac8dbd6196af6c2</Hash>
</Codenesium>*/