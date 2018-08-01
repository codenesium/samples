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
		[Column("id")]
		public int Id { get; private set; }

		[Column("name")]
		public string Name { get; private set; }

		[Column("publicId")]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d2f7e350556f4e83e5bb92cf8e39c68a</Hash>
</Codenesium>*/