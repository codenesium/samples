using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("CountryRegionCurrency", Schema="Sales")]
	public partial class EFCountryRegionCurrency
	{
		public EFCountryRegionCurrency()
		{}

		public void SetProperties(string countryRegionCode,
		                          string currencyCode,
		                          DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode;
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

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
    <Hash>7a7938cb47a95f71ee05d85f5b7ad61d</Hash>
</Codenesium>*/