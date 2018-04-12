using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.Contracts
{
	[Table("Person", Schema="Person")]
	public partial class EFPerson
	{
		public EFPerson()
		{}

		public void SetProperties(
			int businessEntityID,
			string personType,
			bool nameStyle,
			string title,
			string firstName,
			string middleName,
			string lastName,
			string suffix,
			int emailPromotion,
			string additionalContactInfo,
			string demographics,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.PersonType = personType;
			this.NameStyle = nameStyle;
			this.Title = title;
			this.FirstName = firstName;
			this.MiddleName = middleName;
			this.LastName = lastName;
			this.Suffix = suffix;
			this.EmailPromotion = emailPromotion.ToInt();
			this.AdditionalContactInfo = additionalContactInfo;
			this.Demographics = demographics;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("PersonType", TypeName="nchar(2)")]
		public string PersonType { get; set; }

		[Column("NameStyle", TypeName="bit")]
		public bool NameStyle { get; set; }

		[Column("Title", TypeName="nvarchar(8)")]
		public string Title { get; set; }

		[Column("FirstName", TypeName="nvarchar(50)")]
		public string FirstName { get; set; }

		[Column("MiddleName", TypeName="nvarchar(50)")]
		public string MiddleName { get; set; }

		[Column("LastName", TypeName="nvarchar(50)")]
		public string LastName { get; set; }

		[Column("Suffix", TypeName="nvarchar(10)")]
		public string Suffix { get; set; }

		[Column("EmailPromotion", TypeName="int")]
		public int EmailPromotion { get; set; }

		[Column("AdditionalContactInfo", TypeName="xml(-1)")]
		public string AdditionalContactInfo { get; set; }

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>3abbdf6a9b93b2ca32f5d67bf47c45a7</Hash>
</Codenesium>*/