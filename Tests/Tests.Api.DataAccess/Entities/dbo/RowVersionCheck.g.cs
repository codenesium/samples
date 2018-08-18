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

		[MaxLength(50)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("rowVersion")]
		public Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>2f92c7f410e0b4c9b23bcbe405353b51</Hash>
</Codenesium>*/