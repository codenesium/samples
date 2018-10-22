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
			string name)
		{
			this.Description = description;
			this.Id = id;
			this.Name = name;
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
	}
}

/*<Codenesium>
    <Hash>fe9015ad488de326a06a1394a290bc82</Hash>
</Codenesium>*/