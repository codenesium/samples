using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FileServiceNS.Api.DataAccess
{
	[Table("Bucket", Schema="dbo")]
	public partial class EFBucket: AbstractEntityFrameworkPOCO
	{
		public EFBucket()
		{}

		public void SetProperties(
			int id,
			Guid externalId,
			string name)
		{
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name.ToString();
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
    <Hash>83f06c04ddc49b73baf251c03fd9fa4b</Hash>
</Codenesium>*/