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
			DateTime dateOfLastPing,
			bool isActive,
			string name,
			Guid publicId)
		{
			this.Id = id;
			this.DateOfLastPing = dateOfLastPing;
			this.IsActive = isActive;
			this.Name = name;
			this.PublicId = publicId;
		}

		[Column("dateOfLastPing")]
		public virtual DateTime DateOfLastPing { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("isActive")]
		public virtual bool IsActive { get; private set; }

		[MaxLength(90)]
		[Column("name")]
		public virtual string Name { get; private set; }

		[Column("publicId")]
		public virtual Guid PublicId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>08f54f564c081951fde6c0b315686235</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/