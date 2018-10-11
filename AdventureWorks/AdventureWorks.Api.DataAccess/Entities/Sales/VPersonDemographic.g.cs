using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vPersonDemographics", Schema="Sales")]
	public partial class VPersonDemographic : AbstractEntity
	{
		public VPersonDemographic()
		{
		}

		public virtual void SetProperties(
			DateTime? birthDate,
			int businessEntityID,
			DateTime? dateFirstPurchase,
			string education,
			string gender,
			bool? homeOwnerFlag,
			string maritalStatu,
			int? numberCarsOwned,
			int? numberChildrenAtHome,
			string occupation,
			int? totalChildren,
			decimal? totalPurchaseYTD,
			string yearlyIncome)
		{
			this.BirthDate = birthDate;
			this.BusinessEntityID = businessEntityID;
			this.DateFirstPurchase = dateFirstPurchase;
			this.Education = education;
			this.Gender = gender;
			this.HomeOwnerFlag = homeOwnerFlag;
			this.MaritalStatu = maritalStatu;
			this.NumberCarsOwned = numberCarsOwned;
			this.NumberChildrenAtHome = numberChildrenAtHome;
			this.Occupation = occupation;
			this.TotalChildren = totalChildren;
			this.TotalPurchaseYTD = totalPurchaseYTD;
			this.YearlyIncome = yearlyIncome;
		}

		[Column("BirthDate")]
		public DateTime? BirthDate { get; private set; }

		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[Column("DateFirstPurchase")]
		public DateTime? DateFirstPurchase { get; private set; }

		[MaxLength(30)]
		[Column("Education")]
		public string Education { get; private set; }

		[MaxLength(1)]
		[Column("Gender")]
		public string Gender { get; private set; }

		[Column("HomeOwnerFlag")]
		public bool? HomeOwnerFlag { get; private set; }

		[MaxLength(1)]
		[Column("MaritalStatus")]
		public string MaritalStatu { get; private set; }

		[Column("NumberCarsOwned")]
		public int? NumberCarsOwned { get; private set; }

		[Column("NumberChildrenAtHome")]
		public int? NumberChildrenAtHome { get; private set; }

		[MaxLength(30)]
		[Column("Occupation")]
		public string Occupation { get; private set; }

		[Column("TotalChildren")]
		public int? TotalChildren { get; private set; }

		[Column("TotalPurchaseYTD")]
		public decimal? TotalPurchaseYTD { get; private set; }

		[MaxLength(30)]
		[Column("YearlyIncome")]
		public string YearlyIncome { get; private set; }
	}
}

/*<Codenesium>
    <Hash>385b46a603d52071b4de151ac07d8a12</Hash>
</Codenesium>*/