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
			int id,
			int callId,
			int unitId)
		{
			this.Id = id;
			this.CallId = callId;
			this.UnitId = unitId;
		}

		[Column("callId")]
		public virtual int CallId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

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
    <Hash>64fd734aa8ed584a43d2bcfc415e8f16</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/