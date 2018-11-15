using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("CountryRegion", Schema="Person")]
	public partial class CountryRegion : AbstractEntity
	{
		public CountryRegion()
		{
		}

		public virtual void SetProperties(
			string countryRegionCode,
			DateTime modifiedDate,
			string name)
		{
			this.CountryRegionCode = countryRegionCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Key]
		[MaxLength(3)]
		[Column("CountryRegionCode")]
		public virtual string CountryRegionCode { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2573d0fc3a5d726741640c34917fb5af</Hash>
</Codenesium>*/