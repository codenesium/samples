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
		public virtual string AddrLocCity { get; private set; }

		[MaxLength(100)]
		[Column("Addr.Loc.CountryRegion")]
		public virtual string AddrLocCountryRegion { get; private set; }

		[MaxLength(100)]
		[Column("Addr.Loc.State")]
		public virtual string AddrLocState { get; private set; }

		[MaxLength(20)]
		[Column("Addr.PostalCode")]
		public virtual string AddrPostalCode { get; private set; }

		[MaxLength(30)]
		[Column("Addr.Type")]
		public virtual string AddrType { get; private set; }

		[Column("BusinessEntityID")]
		public virtual int? BusinessEntityID { get; private set; }

		[Column("EMail")]
		public virtual string EMail { get; private set; }

		[Column("JobCandidateID")]
		public virtual int JobCandidateID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(30)]
		[Column("Name.First")]
		public virtual string NameFirst { get; private set; }

		[MaxLength(30)]
		[Column("Name.Last")]
		public virtual string NameLast { get; private set; }

		[MaxLength(30)]
		[Column("Name.Middle")]
		public virtual string NameMiddle { get; private set; }

		[MaxLength(30)]
		[Column("Name.Prefix")]
		public virtual string NamePrefix { get; private set; }

		[MaxLength(30)]
		[Column("Name.Suffix")]
		public virtual string NameSuffix { get; private set; }

		[Column("Skills")]
		public virtual string Skill { get; private set; }

		[Column("WebSite")]
		public virtual string WebSite { get; private set; }
	}
}

/*<Codenesium>
    <Hash>88295e6c2d349f4bf573ef8e191bda10</Hash>
</Codenesium>*/