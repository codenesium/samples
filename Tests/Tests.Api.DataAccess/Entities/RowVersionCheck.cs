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
		public virtual int Id { get; private set; }

		[MaxLength(50)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("rowVersion")]
		public virtual Guid RowVersion { get; private set; }
	}
}

/*<Codenesium>
    <Hash>e392e41dc4218ee4071824921aa8c511</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/