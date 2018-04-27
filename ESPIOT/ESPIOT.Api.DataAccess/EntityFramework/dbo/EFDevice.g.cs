using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("Device", Schema="dbo")]
	public partial class EFDevice: AbstractEntityFrameworkPOCO
	{
		public EFDevice()
		{}

		public void SetProperties(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.PublicId = publicId.ToGuid();
		}

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("name", TypeName="varchar(90)")]
		public string Name { get; set; }

		[Column("publicId", TypeName="uniqueidentifier")]
		public Guid PublicId { get; set; }
	}
}

/*<Codenesium>
    <Hash>9c6f7ec387214f4cab9c5c21a25aa065</Hash>
</Codenesium>*/