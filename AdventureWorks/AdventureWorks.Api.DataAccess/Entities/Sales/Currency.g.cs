using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Currency", Schema="Sales")]
	public partial class Currency : AbstractEntity
	{
		public Currency()
		{
		}

		public virtual void SetProperties(
			string currencyCode,
			DateTime modifiedDate,
			string name)
		{
			this.CurrencyCode = currencyCode;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
		}

		[Key]
		[MaxLength(3)]
		[Column("CurrencyCode")]
		public virtual string CurrencyCode { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>4fbd72ab4425537d0ef1dcbc158ed028</Hash>
</Codenesium>*/