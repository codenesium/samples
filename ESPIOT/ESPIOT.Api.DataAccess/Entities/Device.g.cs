using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ESPIOTNS.Api.DataAccess
{
	[Table("Device", Schema="dbo")]
	public partial class Device : AbstractEntity
	{
		public Device()
		{
		}

		public virtual void SetProperties(
			int id,
			string name,
			Guid publicId)
		{
			this.Id = id;
			this.Name = name;
			this.PublicId = publicId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("publicId")]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>61e263e41e74494cfe60c692e5c7329e</Hash>
</Codenesium>*/