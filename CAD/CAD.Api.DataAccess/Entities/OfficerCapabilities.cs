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
			int id,
			int capabilityId,
			int officerId)
		{
			this.Id = id;
			this.CapabilityId = capabilityId;
			this.OfficerId = officerId;
		}

		[Column("capabilityId")]
		public virtual int CapabilityId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("officerId")]
		public virtual int OfficerId { get; private set; }

		[ForeignKey("CapabilityId")]
		public virtual OffCapability CapabilityIdNavigation { get; private set; }

		public void SetCapabilityIdNavigation(OffCapability item)
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
    <Hash>6b531e5bd89d01f2b4da33757a47685c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/