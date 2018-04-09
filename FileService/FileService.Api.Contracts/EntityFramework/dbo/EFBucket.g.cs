using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace FileServiceNS.Api.Contracts
{
	[Table("Bucket", Schema="dbo")]
	public partial class EFBucket
	{
		public EFBucket()
		{}

		public void SetProperties(int id,
		                          string name,
		                          Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.ExternalId = externalId;
		}

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
    <Hash>e4e5527ff15b7a16e4f18f51e24d0a97</Hash>
</Codenesium>*/