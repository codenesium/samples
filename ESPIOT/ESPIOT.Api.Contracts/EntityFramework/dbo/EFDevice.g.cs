using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace ESPIOTNS.Api.Contracts
{
	[Table("Device", Schema="dbo")]
	public partial class EFDevice
	{
		public EFDevice()
		{}

		public void SetProperties(int id,
		                          Guid publicId,
		                          string name)
		{
			this.Id = id.ToInt();
			this.PublicId = publicId;
			this.Name = name;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id {get; set;}

		[Column("publicId", TypeName="uniqueidentifier")]
		public Guid PublicId {get; set;}

		[Column("name", TypeName="varchar(90)")]
		public string Name {get; set;}
	}
}

/*<Codenesium>
    <Hash>d4781484c712540b69c95e0549c50a0c</Hash>
</Codenesium>*/