using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FileServiceNS.Api.DataAccess
{
	[Table("Bucket", Schema="dbo")]
	public partial class Bucket : AbstractEntity
	{
		public Bucket()
		{
		}

		public virtual void SetProperties(
			Guid externalId,
			int id,
			string name)
		{
			this.ExternalId = externalId;
			this.Id = id;
			this.Name = name;
		}

		[Column("externalId")]
		public virtual Guid ExternalId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(255)]
		[Column("name")]
		public virtual string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>fc62f625bd608220b8c6c1fe8113b99b</Hash>
</Codenesium>*/