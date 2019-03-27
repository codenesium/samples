using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PointOfSaleNS.Api.DataAccess
{
	[Table("Sale", Schema="dbo")]
	public partial class Sale : AbstractEntity
	{
		public Sale()
		{
		}

		public virtual void SetProperties(
			int id,
			int customerId,
			DateTime date)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.Date = date;
		}

		[Column("customerId")]
		public virtual int CustomerId { get; private set; }

		[Column("date")]
		public virtual DateTime Date { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ecec7ab358f10c05fb846d3ddabd02f0</Hash>
</Codenesium>*/