using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vJobCandidateEmployment", Schema="HumanResources")]
	public partial class VJobCandidateEmployment : AbstractEntity
	{
		public VJobCandidateEmployment()
		{
		}

		public virtual void SetProperties(
			DateTime? empEndDate,
			string empFunctionCategory,
			string empIndustryCategory,
			string empJobTitle,
			string empLocCity,
			string empLocCountryRegion,
			string empLocState,
			string empOrgName,
			string empResponsibility,
			DateTime? empStartDate,
			int jobCandidateID)
		{
			this.EmpEndDate = empEndDate;
			this.EmpFunctionCategory = empFunctionCategory;
			this.EmpIndustryCategory = empIndustryCategory;
			this.EmpJobTitle = empJobTitle;
			this.EmpLocCity = empLocCity;
			this.EmpLocCountryRegion = empLocCountryRegion;
			this.EmpLocState = empLocState;
			this.EmpOrgName = empOrgName;
			this.EmpResponsibility = empResponsibility;
			this.EmpStartDate = empStartDate;
			this.JobCandidateID = jobCandidateID;
		}

		[Column("Emp.EndDate")]
		public DateTime? EmpEndDate { get; private set; }

		[Column("Emp.FunctionCategory")]
		public string EmpFunctionCategory { get; private set; }

		[Column("Emp.IndustryCategory")]
		public string EmpIndustryCategory { get; private set; }

		[MaxLength(100)]
		[Column("Emp.JobTitle")]
		public string EmpJobTitle { get; private set; }

		[Column("Emp.Loc.City")]
		public string EmpLocCity { get; private set; }

		[Column("Emp.Loc.CountryRegion")]
		public string EmpLocCountryRegion { get; private set; }

		[Column("Emp.Loc.State")]
		public string EmpLocState { get; private set; }

		[MaxLength(100)]
		[Column("Emp.OrgName")]
		public string EmpOrgName { get; private set; }

		[Column("Emp.Responsibility")]
		public string EmpResponsibility { get; private set; }

		[Column("Emp.StartDate")]
		public DateTime? EmpStartDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("JobCandidateID")]
		public int JobCandidateID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d64a24994b34a604b1c7a9091e852f17</Hash>
</Codenesium>*/