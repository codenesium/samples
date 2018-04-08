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

		[ForeignKey("CountryRegionCode")]
		public virtual EFCountryRegion CountryRegion { get; set; }
		[ForeignKey("CurrencyCode")]
		public virtual EFCurrency Currency { get; set; }
	}
}

/*<Codenesium>
    <Hash>8236fd8054449671a534d7dfaa2e796d</Hash>
</Codenesium>*/