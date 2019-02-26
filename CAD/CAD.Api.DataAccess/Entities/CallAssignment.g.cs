using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("CallAssignment", Schema="dbo")]
	public partial class CallAssignment : AbstractEntity
	{
		public CallAssignment()
		{
		}

		public virtual void SetProperties(
			int callId,
			int unitId)
		{
			this.CallId = callId;
			this.UnitId = unitId;
		}

		[Key]
		[Column("callId")]
		public virtual int CallId { get; private set; }

		[Key]
		[Column("unitId")]
		public virtual int UnitId { get; private set; }

		[ForeignKey("CallId")]
		public virtual Call CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(Call item)
		{
			this.CallIdNavigation = item;
		}

		[ForeignKey("UnitId")]
		public virtual Unit UnitIdNavigation { get; private set; }

		public void SetUnitIdNavigation(Unit item)
		{
			this.UnitIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>80776cff879209bee0600514ad33d90e</Hash>
</Codenesium>*/