using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerNS.Api.DataAccess
{
	[Table("Family", Schema="dbo")]
	public partial class Family : AbstractEntity
	{
		public Family()
		{
		}

		public virtual void SetProperties(
			int id,
			string note,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone,
			bool isDeleted)
		{
			this.Id = id;
			this.Note = note;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
			this.IsDeleted = isDeleted;
		}

		[Key]
		[Column("id")]
		public int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public string Note { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactEmail")]
		public string PrimaryContactEmail { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactFirstName")]
		public string PrimaryContactFirstName { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactLastName")]
		public string PrimaryContactLastName { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactPhone")]
		public string PrimaryContactPhone { get; private set; }

		[Column("isDeleted")]
		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9235fead2b0aa78b96165dd6ed8f06d7</Hash>
</Codenesium>*/