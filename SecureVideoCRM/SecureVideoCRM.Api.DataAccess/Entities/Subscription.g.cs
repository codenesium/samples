using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SecureVideoCRMNS.Api.DataAccess
{
	[Table("Subscription", Schema="dbo")]
	public partial class Subscription : AbstractEntity
	{
		public Subscription()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			string stripePlanName)
		{
			this.Id = id;
			this.Name = name;
			this.StripePlanName = stripePlanName;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[MaxLength(128)]
		[Column("stripePlanName")]
		public virtual string StripePlanName { get; private set; }
	}
}

/*<Codenesium>
    <Hash>74d6f567eb6790d0c91c62e00c86ab6b</Hash>
</Codenesium>*/