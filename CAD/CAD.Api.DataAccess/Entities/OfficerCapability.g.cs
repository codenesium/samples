using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("OfficerCapabilities", Schema="dbo")]
	public partial class OfficerCapability : AbstractEntity
	{
		public OfficerCapability()
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

		[ForeignKey("CapabilityId")]
		public virtual OfficerCapability CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(OfficerCapability item)
		{
			this.CapabilityIdNavigation = item;
		}

		[ForeignKey("OfficerId")]
		public virtual Officer OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(Officer item)
		{
			this.OfficerIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>fddc8d9967fd7f99250f522b97eb260e</Hash>
</Codenesium>*/