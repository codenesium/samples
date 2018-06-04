using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class PersonCreditCard: AbstractEntity
	{
		public PersonCreditCard()
		{}

		public void SetProperties(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID.ToInt();
			this.CreditCardID = creditCardID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[Column("BusinessEntityID", TypeName="int")]
		public int BusinessEntityID { get; private set; }

		[Column("CreditCardID", TypeName="int")]
		public int CreditCardID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[ForeignKey("CreditCardID")]
		public virtual CreditCard CreditCard { get; set; }
	}
}

/*<Codenesium>
    <Hash>86bdc7ec6c767921b526a6486390b77b</Hash>
</Codenesium>*/