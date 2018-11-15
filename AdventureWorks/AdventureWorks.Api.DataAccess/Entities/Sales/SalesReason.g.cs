using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SalesReason", Schema="Sales")]
	public partial class SalesReason : AbstractEntity
	{
		public SalesReason()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			string reasonType,
			int salesReasonID)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
			this.SalesReasonID = salesReasonID;
		}

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[MaxLength(50)]
		[Column("ReasonType")]
		public virtual string ReasonType { get; private set; }

		[Key]
		[Column("SalesReasonID")]
		public virtual int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ae9ce28715cb9c890fc7c701e4bad7f5</Hash>
</Codenesium>*/