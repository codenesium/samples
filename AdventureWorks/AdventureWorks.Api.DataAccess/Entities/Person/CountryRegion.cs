using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CountryRegion", Schema="Person")]
	public partial class CountryRegion: AbstractEntity
	{
		public CountryRegion()
		{}

		public void SetProperties(
			string countryRegionCode,
			DateTime modifiedDate,
			string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		[Key]
		[Column("CountryRegionCode", TypeName="nvarchar(3)")]
		public string CountryRegionCode { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("Name", TypeName="nvarchar(50)")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>246e5e01515d7cd1847695fda95d0262</Hash>
</Codenesium>*/