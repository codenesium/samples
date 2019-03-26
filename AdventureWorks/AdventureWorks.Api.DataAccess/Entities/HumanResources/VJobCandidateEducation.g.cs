using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vJobCandidateEducation", Schema="HumanResources")]
	public partial class VJobCandidateEducation : AbstractEntity
	{
		public VJobCandidateEducation()
		{
		}

		public virtual void SetProperties(
			string eduDegree,
			DateTime? eduEndDate,
			string eduGPA,
			string eduGPAScale,
			string eduLevel,
			string eduLocCity,
			string eduLocCountryRegion,
			string eduLocState,
			string eduMajor,
			string eduMinor,
			string eduSchool,
			DateTime? eduStartDate,
			int jobCandidateID)
		{
			this.EduDegree = eduDegree;
			this.EduEndDate = eduEndDate;
			this.EduGPA = eduGPA;
			this.EduGPAScale = eduGPAScale;
			this.EduLevel = eduLevel;
			this.EduLocCity = eduLocCity;
			this.EduLocCountryRegion = eduLocCountryRegion;
			this.EduLocState = eduLocState;
			this.EduMajor = eduMajor;
			this.EduMinor = eduMinor;
			this.EduSchool = eduSchool;
			this.EduStartDate = eduStartDate;
			this.JobCandidateID = jobCandidateID;
		}

		[MaxLength(50)]
		[Column("Edu.Degree")]
		public virtual string EduDegree { get; private set; }

		[Column("Edu.EndDate")]
		public virtual DateTime? EduEndDate { get; private set; }

		[MaxLength(5)]
		[Column("Edu.GPA")]
		public virtual string EduGPA { get; private set; }

		[MaxLength(5)]
		[Column("Edu.GPAScale")]
		public virtual string EduGPAScale { get; private set; }

		[Column("Edu.Level")]
		public virtual string EduLevel { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.City")]
		public virtual string EduLocCity { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.CountryRegion")]
		public virtual string EduLocCountryRegion { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.State")]
		public virtual string EduLocState { get; private set; }

		[MaxLength(50)]
		[Column("Edu.Major")]
		public virtual string EduMajor { get; private set; }

		[MaxLength(50)]
		[Column("Edu.Minor")]
		public virtual string EduMinor { get; private set; }

		[MaxLength(100)]
		[Column("Edu.School")]
		public virtual string EduSchool { get; private set; }

		[Column("Edu.StartDate")]
		public virtual DateTime? EduStartDate { get; private set; }

		[Column("JobCandidateID")]
		public virtual int JobCandidateID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>080d430f9cfbb36c0e6786325cfdb15b</Hash>
</Codenesium>*/