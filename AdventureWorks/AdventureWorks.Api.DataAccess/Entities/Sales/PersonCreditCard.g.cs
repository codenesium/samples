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
		public virtual CreditCard CreditCardNavigation { get; private set; }

		public void SetCreditCardNavigation(CreditCard item)
		{
			this.CreditCardNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>40d7984f6631e0982ed9f1f419f3ab84</Hash>
</Codenesium>*/