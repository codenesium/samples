using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CountryRegion", Schema="Person")]
	public partial class EFCountryRegion: AbstractEntityFrameworkPOCO
	{
		public EFCountryRegion()
		{}

		public void SetProperties(
			string countryRegionCode,
			string name,
			DateTime modifiedDate)
		{
			this.CountryRegionCode = countryRegionCode.ToString();
			this.Name = name.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }
	}
}

/*<Codenesium>
    <Hash>c4bcf73f73b1422ae4490f63f40fdb2f</Hash>
</Codenesium>*/