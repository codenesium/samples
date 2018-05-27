using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("Bucket", Schema="dbo")]
	public partial class Bucket:AbstractEntityFrameworkDTO
	{
		public Bucket()
		{}

		public void SetProperties(
			int id,
			Guid externalId,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="nvarchar(255)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>701d0b0a6130479f6a5047b0fbc13aa4</Hash>
</Codenesium>*/