using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("OfficerCapabilities", Schema="dbo")]
	public partial class OfficerCapabilities : AbstractEntity
	{
		public OfficerCapabilities()
		{
		}

		public virtual void SetProperties(
			int capabilityId,
			int officerId)
		{
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;
		}

		[Key]
		[Column("capabilityId")]
		public virtual int CapabilityId { get; private set; }

		[Key]
		[Column("officerId")]
		public virtual int OfficerId { get; private set; }

		[ForeignKey("OfficerId")]
		public virtual Officer OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(Officer item)
		{
			this.OfficerIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>c359aed7692bdf9a7af5e04aff6553ab</Hash>
</Codenesium>*/