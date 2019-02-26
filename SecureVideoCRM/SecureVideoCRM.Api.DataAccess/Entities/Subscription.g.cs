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
			string name)
		{
			this.Id = id;
			this.Name = name;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>3174d6ebbcc623c5ce25b3f8908ae706</Hash>
</Codenesium>*/