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
		public virtual int BusinessEntityID { get; private set; }

		[Key]
		[Column("CreditCardID")]
		public virtual int CreditCardID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[ForeignKey("CreditCardID")]
		public virtual CreditCard CreditCardIDNavigation { get; private set; }

		public void SetCreditCardIDNavigation(CreditCard item)
		{
			this.CreditCardIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>02854a573c79dcba1dba7f8596a8a766</Hash>
</Codenesium>*/