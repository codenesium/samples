using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("PersonPhone", Schema="Person")]
	public partial class EFPersonPhone
	{
		public EFPersonPhone()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID {get; set;}

		[Column("PhoneNumber", TypeName="nvarchar(25)")]
		public string PhoneNumber {get; set;}

		[Column("PhoneNumberTypeID", TypeName="int")]
		public int PhoneNumberTypeID {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		[ForeignKey("BusinessEntityID")]
		public virtual EFPerson Person { get; set; }
		[ForeignKey("PhoneNumberTypeID")]
		public virtual EFPhoneNumberType PhoneNumberType { get; set; }
	}
}

/*<Codenesium>
    <Hash>cb0f70d21298debcd6da4a3538496870</Hash>
</Codenesium>*/