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

		public void SetProperties(
			int id,
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
		public int Id { get; set; }

		[Column("publicId", TypeName="uniqueidentifier")]
		public Guid PublicId { get; set; }

		[Column("name", TypeName="varchar(90)")]
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>7d0fbcbe2887c77d4c5ac487921b99b7</Hash>
</Codenesium>*/