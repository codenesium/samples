using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("Bucket", Schema="dbo")]
	public partial class Bucket:AbstractEntity
	{
		public Bucket()
		{}

		public void SetProperties(
			Guid externalId,
			int id,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; private set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="nvarchar(255)")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f7f35f596c3aca30a28118c91b0c6799</Hash>
</Codenesium>*/