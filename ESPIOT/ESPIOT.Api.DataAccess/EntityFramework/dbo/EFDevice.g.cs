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
			Guid publicId,
			string name)
		{
			this.Id = id.ToInt();
			this.PublicId = publicId.ToGuid();
			this.Name = name.ToString();
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
    <Hash>e512dedfb730189d553c53dc3684ba0e</Hash>
</Codenesium>*/