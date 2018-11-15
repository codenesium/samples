using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
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
			string name)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
		}

		[MaxLength(128)]
		[Column("description")]
		public virtual string Description { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(128)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a2bfb311897c35f78e99ab40c8c0c789</Hash>
</Codenesium>*/