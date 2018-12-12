using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("__EFMigrationsHistory", Schema="dbo")]
	public partial class Efmigrationshistory : AbstractEntity
	{
		public Efmigrationshistory()
		{
		}

		public virtual void SetProperties(
			string migrationId,
			string productVersion)
		{
			this.MigrationId = migrationId;
			this.ProductVersion = productVersion;
		}

		[Key]
		[MaxLength(150)]
		[Column("MigrationId")]
		public virtual string MigrationId { get; private set; }

		[MaxLength(32)]
		[Column("ProductVersion")]
		public virtual string ProductVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a5290467f529cfc676e40700abedb828</Hash>
</Codenesium>*/