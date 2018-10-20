using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("SpaceFeature", Schema="dbo")]
	public partial class SpaceFeature : AbstractEntity
	{
		public SpaceFeature()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			bool isDeleted)
		{
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ebcd2fdb11ad1889103b67a62133cae0</Hash>
</Codenesium>*/