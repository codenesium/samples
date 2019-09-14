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
			int id,
			Guid externalId,
			string name)
		{
			this.Id = id;
			this.ExternalId = externalId;
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
    <Hash>038a6491d83556a658faaffc0ab77298</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/