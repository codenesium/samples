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
		public string EduDegree { get; private set; }

		[Column("Edu.EndDate")]
		public DateTime? EduEndDate { get; private set; }

		[MaxLength(5)]
		[Column("Edu.GPA")]
		public string EduGPA { get; private set; }

		[MaxLength(5)]
		[Column("Edu.GPAScale")]
		public string EduGPAScale { get; private set; }

		[Column("Edu.Level")]
		public string EduLevel { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.City")]
		public string EduLocCity { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.CountryRegion")]
		public string EduLocCountryRegion { get; private set; }

		[MaxLength(100)]
		[Column("Edu.Loc.State")]
		public string EduLocState { get; private set; }

		[MaxLength(50)]
		[Column("Edu.Major")]
		public string EduMajor { get; private set; }

		[MaxLength(50)]
		[Column("Edu.Minor")]
		public string EduMinor { get; private set; }

		[MaxLength(100)]
		[Column("Edu.School")]
		public string EduSchool { get; private set; }

		[Column("Edu.StartDate")]
		public DateTime? EduStartDate { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("JobCandidateID")]
		public int JobCandidateID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e79597bd0889c9eec0bb238e68e06c70</Hash>
</Codenesium>*/