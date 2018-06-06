using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStatus", Schema="dbo")]
	public partial class PipelineStatus: AbstractEntity
	{
		public PipelineStatus()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name;
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; private set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>7f05d6cae04d18b0faaa819dd7c83fac</Hash>
</Codenesium>*/