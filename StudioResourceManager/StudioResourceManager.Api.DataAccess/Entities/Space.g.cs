using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("Space", Schema="dbo")]
	public partial class Space : AbstractEntity
	{
		public Space()
		{
		}

		public virtual void SetProperties(
			string description,
			int id,
			string name,
			bool isDeleted)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
			this.IsDeleted = isDeleted;
		}

		[MaxLength(128)]
		[Column("description")]
		public string Description { get; private set; }

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
    <Hash>23efa745c9c6870b22554ea698f94715</Hash>
</Codenesium>*/