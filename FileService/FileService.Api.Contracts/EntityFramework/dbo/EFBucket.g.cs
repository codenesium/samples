using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("Bucket", Schema="dbo")]
	public partial class EFBucket
	{
		public EFBucket()
		{}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("name", TypeName="nvarchar(255)")]
		public string Name {get; set;}

		[Column("externalId", TypeName="uniqueidentifier")]
		public Guid ExternalId {get; set;}
	}
}

/*<Codenesium>
    <Hash>4d7aaceaac6bde4a044ab74687353257</Hash>
</Codenesium>*/