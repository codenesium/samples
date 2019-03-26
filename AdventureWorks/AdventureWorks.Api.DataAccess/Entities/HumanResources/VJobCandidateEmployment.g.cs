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
		public virtual DateTime? EmpEndDate { get; private set; }

		[Column("Emp.FunctionCategory")]
		public virtual string EmpFunctionCategory { get; private set; }

		[Column("Emp.IndustryCategory")]
		public virtual string EmpIndustryCategory { get; private set; }

		[MaxLength(100)]
		[Column("Emp.JobTitle")]
		public virtual string EmpJobTitle { get; private set; }

		[Column("Emp.Loc.City")]
		public virtual string EmpLocCity { get; private set; }

		[Column("Emp.Loc.CountryRegion")]
		public virtual string EmpLocCountryRegion { get; private set; }

		[Column("Emp.Loc.State")]
		public virtual string EmpLocState { get; private set; }

		[MaxLength(100)]
		[Column("Emp.OrgName")]
		public virtual string EmpOrgName { get; private set; }

		[Column("Emp.Responsibility")]
		public virtual string EmpResponsibility { get; private set; }

		[Column("Emp.StartDate")]
		public virtual DateTime? EmpStartDate { get; private set; }

		[Column("JobCandidateID")]
		public virtual int JobCandidateID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>cd1103415450a000dc34a4e5e6f30c76</Hash>
</Codenesium>*/