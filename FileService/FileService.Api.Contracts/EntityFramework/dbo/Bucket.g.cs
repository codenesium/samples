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
		public int id {get; set;}
		public string name {get; set;}
		public Guid externalId {get; set;}
	}
}

/*<Codenesium>
    <Hash>ae24a60ab10c6bf860a6a0ffb6da7f3d</Hash>
</Codenesium>*/