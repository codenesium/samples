using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("PersonCreditCard", Schema="Sales")]
	public partial class PersonCreditCard : AbstractEntity
	{
		public PersonCreditCard()
		{
		}

		public virtual void SetProperties(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			this.BusinessEntityID = businessEntityID;
			this.CreditCardID = creditCardID;
			this.ModifiedDate = modifiedDate;
		}

		[Key]
		[Column("BusinessEntityID")]
		public int BusinessEntityID { get; private set; }

		[Column("CreditCardID")]
		public int CreditCardID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[ForeignKey("CreditCardID")]
		public virtual CreditCard CreditCardNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>686647a73db9272ff960fde513a0c8a6</Hash>
</Codenesium>*/