using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vStoreWithDemographics", Schema="Sales")]
	public partial class VStoreWithDemographic : AbstractEntity
	{
		public VStoreWithDemographic()
		{
		}

		public virtual void SetProperties(
			decimal? annualRevenue,
			decimal? annualSale,
			string bankName,
			string brand,
			int businessEntityID,
			string businessType,
			string internet,
			string name,
			int? numberEmployee,
			string specialty,
			int? squareFoot,
			int? yearOpened)
		{
			this.AnnualRevenue = annualRevenue;
			this.AnnualSale = annualSale;
			this.BankName = bankName;
			this.Brand = brand;
			this.BusinessEntityID = businessEntityID;
			this.BusinessType = businessType;
			this.Internet = internet;
			this.Name = name;
			this.NumberEmployee = numberEmployee;
			this.Specialty = specialty;
			this.SquareFoot = squareFoot;
			this.YearOpened = yearOpened;
		}

		[Column("AnnualRevenue")]
		public decimal? AnnualRevenue { get; private set; }

		[Column("AnnualSales")]
		public decimal? AnnualSale { get; private set; }

		[MaxLength(50)]
		[Column("BankName")]
		public string BankName { get; private set; }

		[MaxLength(30)]
		[Column("Brands")]
		public string Brand { get; private set; }

		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[MaxLength(5)]
		[Column("BusinessType")]
		public string BusinessType { get; private set; }

		[MaxLength(30)]
		[Column("Internet")]
		public string Internet { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[Column("NumberEmployees")]
		public int? NumberEmployee { get; private set; }

		[MaxLength(50)]
		[Column("Specialty")]
		public string Specialty { get; private set; }

		[Column("SquareFeet")]
		public int? SquareFoot { get; private set; }

		[Column("YearOpened")]
		public int? YearOpened { get; private set; }
	}
}

/*<Codenesium>
    <Hash>648ca73000c8d572c7d5a2dc2abd5bbd</Hash>
</Codenesium>*/