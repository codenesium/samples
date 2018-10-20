using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TestsNS.Api.DataAccess
{
	[Table("RowVersionCheck", Schema="dbo")]
	public partial class RowVersionCheck : AbstractEntity
	{
		public RowVersionCheck()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			Guid rowVersion)
		{
			this.Id = id;
			this.Name = name;
			this.RowVersion = rowVersion;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowVersion")]
		public Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8711e05e423acf7e7a89f0cd71b09598</Hash>
</Codenesium>*/