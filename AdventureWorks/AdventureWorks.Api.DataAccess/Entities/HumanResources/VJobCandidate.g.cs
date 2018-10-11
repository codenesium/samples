using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("vJobCandidate", Schema="HumanResources")]
	public partial class VJobCandidate : AbstractEntity
	{
		public VJobCandidate()
		{
		}

		public virtual void SetProperties(
			string addrLocCity,
			string addrLocCountryRegion,
			string addrLocState,
			string addrPostalCode,
			string addrType,
			int? businessEntityID,
			string eMail,
			int jobCandidateID,
			DateTime modifiedDate,
			string nameFirst,
			string nameLast,
			string nameMiddle,
			string namePrefix,
			string nameSuffix,
			string skill,
			string webSite)
		{
			this.AddrLocCity = addrLocCity;
			this.AddrLocCountryRegion = addrLocCountryRegion;
			this.AddrLocState = addrLocState;
			this.AddrPostalCode = addrPostalCode;
			this.AddrType = addrType;
			this.BusinessEntityID = businessEntityID;
			this.EMail = eMail;
			this.JobCandidateID = jobCandidateID;
			this.ModifiedDate = modifiedDate;
			this.NameFirst = nameFirst;
			this.NameLast = nameLast;
			this.NameMiddle = nameMiddle;
			this.NamePrefix = namePrefix;
			this.NameSuffix = nameSuffix;
			this.Skill = skill;
			this.WebSite = webSite;
		}

		[MaxLength(100)]
		[Column("Addr.Loc.City")]
		public string AddrLocCity { get; private set; }

		[MaxLength(100)]
		[Column("Addr.Loc.CountryRegion")]
		public string AddrLocCountryRegion { get; private set; }

		[MaxLength(100)]
		[Column("Addr.Loc.State")]
		public string AddrLocState { get; private set; }

		[MaxLength(20)]
		[Column("Addr.PostalCode")]
		public string AddrPostalCode { get; private set; }

		[MaxLength(30)]
		[Column("Addr.Type")]
		public string AddrType { get; private set; }

		[Column("BusinessEntityID")]
		public int? BusinessEntityID { get; private set; }

		[Column("EMail")]
		public string EMail { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("JobCandidateID")]
		public int JobCandidateID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(30)]
		[Column("Name.First")]
		public string NameFirst { get; private set; }

		[MaxLength(30)]
		[Column("Name.Last")]
		public string NameLast { get; private set; }

		[MaxLength(30)]
		[Column("Name.Middle")]
		public string NameMiddle { get; private set; }

		[MaxLength(30)]
		[Column("Name.Prefix")]
		public string NamePrefix { get; private set; }

		[MaxLength(30)]
		[Column("Name.Suffix")]
		public string NameSuffix { get; private set; }

		[Column("Skills")]
		public string Skill { get; private set; }

		[Column("WebSite")]
		public string WebSite { get; private set; }
	}
}

/*<Codenesium>
    <Hash>31258fb98f40334d162fcb311b73f9d9</Hash>
</Codenesium>*/