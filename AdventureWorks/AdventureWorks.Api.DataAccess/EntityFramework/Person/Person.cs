using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Person", Schema="Person")]
	public partial class Person:AbstractEntityFrameworkDTO
	{
		public Person()
		{}

		public void SetProperties(
			int businessEntityID,
			string additionalContactInfo,
			string demographics,
			int emailPromotion,
			string firstName,
			string lastName,
			string middleName,
			DateTime modifiedDate,
			bool nameStyle,
			string personType,
			Guid rowguid,
			string suffix,
			string title)
		{
			this.AdditionalContactInfo = additionalContactInfo;
			this.BusinessEntityID = businessEntityID.ToInt();
			this.Demographics = demographics;
			this.EmailPromotion = emailPromotion.ToInt();
			this.FirstName = firstName;
			this.LastName = lastName;
			this.MiddleName = middleName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.NameStyle = nameStyle.ToBoolean();
			this.PersonType = personType;
			this.Rowguid = rowguid.ToGuid();
			this.Suffix = suffix;
			this.Title = title;
		}

		[Column("AdditionalContactInfo", TypeName="xml(-1)")]
		public string AdditionalContactInfo { get; set; }

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; set; }

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics { get; set; }

		[Column("EmailPromotion", TypeName="int")]
		public int EmailPromotion { get; set; }

		[Column("FirstName", TypeName="nvarchar(50)")]
		public string FirstName { get; set; }

		[Column("LastName", TypeName="nvarchar(50)")]
		public string LastName { get; set; }

		[Column("MiddleName", TypeName="nvarchar(50)")]
		public string MiddleName { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("NameStyle", TypeName="bit")]
		public bool NameStyle { get; set; }

		[Column("PersonType", TypeName="nchar(2)")]
		public string PersonType { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("Suffix", TypeName="nvarchar(10)")]
		public string Suffix { get; set; }

		[Column("Title", TypeName="nvarchar(8)")]
		public string Title { get; set; }
	}
}

/*<Codenesium>
    <Hash>6689c83fa9d39d981c2743e8ec82a435</Hash>
</Codenesium>*/