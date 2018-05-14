using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Currency", Schema="Sales")]
	public partial class Currency: AbstractEntityFrameworkPOCO
	{
		public Currency()
		{}

		public void SetProperties(
			string currencyCode,
			DateTime modifiedDate,
			string name)
		{
			this.CurrencyCode = currencyCode.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
		}

		[Key]
		[Column("CurrencyCode", TypeName="nchar(3)")]
		public string CurrencyCode { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>306f9fbe4553ba0a669ac7a3a1ecb9de</Hash>
</Codenesium>*/