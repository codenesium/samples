using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FileServiceNS.Api.Contracts
{
	[Table("Bucket", Schema="dbo")]
	public partial class Bucket
	{
		public Bucket()
		{}

		public Guid externalId {get; set;}
		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>9077eeb32be6ca38d10dc4a90ee0e173</Hash>
</Codenesium>*/