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
		public virtual int Id { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("publicId")]
		public virtual Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>85b2715760a90c9a84c6ab41f6993601</Hash>
</Codenesium>*/