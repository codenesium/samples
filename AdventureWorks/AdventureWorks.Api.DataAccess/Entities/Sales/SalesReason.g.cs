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
		public DateTime ModifiedDate { get; private set; }

		[MaxLength(50)]
		[Column("Name")]
		public string Name { get; private set; }

		[MaxLength(50)]
		[Column("ReasonType")]
		public string ReasonType { get; private set; }

		[Key]
		[Column("SalesReasonID")]
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0e6f08e1129f021146961bb382702fe1</Hash>
</Codenesium>*/