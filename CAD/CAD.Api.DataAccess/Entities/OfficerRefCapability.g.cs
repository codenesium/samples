using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("OfficerRefCapability", Schema="dbo")]
	public partial class OfficerRefCapability : AbstractEntity
	{
		public OfficerRefCapability()
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
    <Hash>f3cb999f5b57ed113219e476cca272a3</Hash>
</Codenesium>*/