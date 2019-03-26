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
			int salesReasonID,
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.SalesReasonID = salesReasonID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
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
    <Hash>20d8c7d27a4ec4d567d4d3faabd9873a</Hash>
</Codenesium>*/