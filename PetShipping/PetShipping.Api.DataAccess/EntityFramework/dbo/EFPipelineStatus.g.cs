using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace PetShippingNS.Api.DataAccess
{
	[Table("PipelineStatus", Schema="dbo")]
	public partial class EFPipelineStatus: AbstractEntityFrameworkPOCO
	{
		public EFPipelineStatus()
		{}

		public void SetProperties(
			int id,
			string name)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(128)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>b8fcb93c5e78e1b4788defad7062e360</Hash>
</Codenesium>*/