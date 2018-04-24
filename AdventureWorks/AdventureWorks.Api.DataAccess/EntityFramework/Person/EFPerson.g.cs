using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Person", Schema="Person")]
	public partial class EFPerson: AbstractEntityFrameworkPOCO
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
			this.PersonType = personType.ToString();
			this.NameStyle = nameStyle.ToBoolean();
			this.Title = title.ToString();
			this.FirstName = firstName.ToString();
			this.MiddleName = middleName.ToString();
			this.LastName = lastName.ToString();
			this.Suffix = suffix.ToString();
			this.EmailPromotion = emailPromotion.ToInt();
			this.AdditionalContactInfo = additionalContactInfo;
			this.Demographics = demographics;
			this.Rowguid = rowguid.ToGuid();
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
    <Hash>ad3309af2088467ae1f53f23b48a5bbf</Hash>
</Codenesium>*/