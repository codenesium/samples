using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CountryRegionCurrency", Schema="Sales")]
	public partial class CountryRegionCurrency: AbstractEntityFrameworkPOCO
	{
		public CountryRegionCurrency()
		{}

		public void SetProperties(
			string countryRegionCode,
			string currencyCode,
			DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode.ToString();
			this.CurrencyCode = currencyCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; set; }

		[Column("CurrencyCode", TypeName="nchar(3)")]
		public string CurrencyCode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("CurrencyCode")]
		public virtual Currency Currency { get; set; }
	}
}

/*<Codenesium>
    <Hash>d118866c006837f112aa3527e4065d8d</Hash>
</Codenesium>*/