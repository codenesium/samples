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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }

		[Column("rowVersion")]
		public Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>605fd33e4ed8afb5e0e0f2a0f244c6c6</Hash>
</Codenesium>*/