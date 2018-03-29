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
		public int BusinessEntityID {get; set;}
		public string PersonType {get; set;}
		public bool NameStyle {get; set;}
		public string Title {get; set;}
		public string FirstName {get; set;}
		public string MiddleName {get; set;}
		public string LastName {get; set;}
		public string Suffix {get; set;}
		public int EmailPromotion {get; set;}
		public string AdditionalContactInfo {get; set;}
		public string Demographics {get; set;}
		public Guid rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFBusinessEntity BusinessEntityRef { get; set; }
	}
}

/*<Codenesium>
    <Hash>c01332138fc62e69b4ce0eb18c174282</Hash>
</Codenesium>*/