using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Person", Schema="Person")]
	public partial class EFPerson
	{
		public EFPerson()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("PersonType", TypeName="nchar(2)")]
		public string PersonType {get; set;}

		[Column("NameStyle", TypeName="bit")]
		public bool NameStyle {get; set;}

		[Column("Title", TypeName="nvarchar(8)")]
		public string Title {get; set;}

		[Column("FirstName", TypeName="nvarchar(50)")]
		public string FirstName {get; set;}

		[Column("MiddleName", TypeName="nvarchar(50)")]
		public string MiddleName {get; set;}

		[Column("LastName", TypeName="nvarchar(50)")]
		public string LastName {get; set;}

		[Column("Suffix", TypeName="nvarchar(10)")]
		public string Suffix {get; set;}

		[Column("EmailPromotion", TypeName="int")]
		public int EmailPromotion {get; set;}

		[Column("AdditionalContactInfo", TypeName="xml(-1)")]
		public string AdditionalContactInfo {get; set;}

		[Column("Demographics", TypeName="xml(-1)")]
		public string Demographics {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFBusinessEntity BusinessEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>12b5404172c441825a2345dc9e82e942</Hash>
</Codenesium>*/