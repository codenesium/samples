using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("UnitOfficer", Schema="dbo")]
	public partial class UnitOfficer : AbstractEntity
	{
		public UnitOfficer()
		{
		}

		public virtual void SetProperties(
			int id,
			int officerId,
			int unitId)
		{
			this.Id = id;
			this.OfficerId = officerId;
			this.UnitId = unitId;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("officerId")]
		public virtual int OfficerId { get; private set; }

		[Column("unitId")]
		public virtual int UnitId { get; private set; }

		[ForeignKey("OfficerId")]
		public virtual Officer OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(Officer item)
		{
			this.OfficerIdNavigation = item;
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
    <Hash>12e90eaabe0bf6a30b6be3be71440927</Hash>
</Codenesium>*/