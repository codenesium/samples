using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
namespace sample1NS.Api.Contracts
{
	[Table("Organization", Schema="dbo")]
	public partial class Organization
	{
		public Organization()
		{}

		[Key]
		public int id {get; set;}
		public string name {get; set;}
	}
}

/*<Codenesium>
    <Hash>adb35db0129c2504be904b726cc20340</Hash>
</Codenesium>*/