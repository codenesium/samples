using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("Device", Schema="dbo")]
	public partial class Device:AbstractEntityFrameworkPOCO
	{
		public Device()
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
    <Hash>53016bc9832c8b78bd51d2015bfd0639</Hash>
</Codenesium>*/