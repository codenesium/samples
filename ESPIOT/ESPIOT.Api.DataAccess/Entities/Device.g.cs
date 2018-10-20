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

		[MaxLength(90)]
		[Column("name")]
		public string Name { get; private set; }

		[Column("publicId")]
		public Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5673432a76107e64612c9ae73e61f0df</Hash>
</Codenesium>*/