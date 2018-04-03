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
		public int businessEntityID {get; set;}
		public string personType {get; set;}
		public bool nameStyle {get; set;}
		public string title {get; set;}
		public string firstName {get; set;}
		public string middleName {get; set;}
		public string lastName {get; set;}
		public string suffix {get; set;}
		public int emailPromotion {get; set;}
		public string additionalContactInfo {get; set;}
		public string demographics {get; set;}
		public Guid rowguid {get; set;}
		public DateTime modifiedDate {get; set;}
	}
}

/*<Codenesium>
    <Hash>52cc006cb5c3d57da69cd97fda2e3fb9</Hash>
</Codenesium>*/