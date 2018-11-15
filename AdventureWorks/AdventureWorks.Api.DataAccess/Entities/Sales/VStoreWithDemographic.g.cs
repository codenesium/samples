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
		public virtual decimal? AnnualRevenue { get; private set; }

		[Column("AnnualSales")]
		public virtual decimal? AnnualSale { get; private set; }

		[MaxLength(50)]
		[Column("BankName")]
		public virtual string BankName { get; private set; }

		[MaxLength(30)]
		[Column("Brands")]
		public virtual string Brand { get; private set; }

		[Column("BusinessEntityID")]
		public virtual int BusinessEntityID { get; private set; }

		[MaxLength(5)]
		[Column("BusinessType")]
		public virtual string BusinessType { get; private set; }

		[MaxLength(30)]
		[Column("Internet")]
		public virtual string Internet { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("NumberEmployees")]
		public virtual int? NumberEmployee { get; private set; }

		[MaxLength(50)]
		[Column("Specialty")]
		public virtual string Specialty { get; private set; }

		[Column("SquareFeet")]
		public virtual int? SquareFoot { get; private set; }

		[Column("YearOpened")]
		public virtual int? YearOpened { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5b6d7ec5e3b6f23c50ac79e1dcd3e128</Hash>
</Codenesium>*/