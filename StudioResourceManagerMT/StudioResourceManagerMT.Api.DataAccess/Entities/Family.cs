using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Family", Schema="dbo")]
	public partial class Family : AbstractEntity
	{
		public Family()
		{
		}

		public virtual void SetProperties(
			int id,
			string notes,
			string primaryContactEmail,
			string primaryContactFirstName,
			string primaryContactLastName,
			string primaryContactPhone)
		{
			this.Id = id;
			this.Notes = notes;
			this.PrimaryContactEmail = primaryContactEmail;
			this.PrimaryContactFirstName = primaryContactFirstName;
			this.PrimaryContactLastName = primaryContactLastName;
			this.PrimaryContactPhone = primaryContactPhone;
		}

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public virtual string Notes { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactEmail")]
		public virtual string PrimaryContactEmail { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactFirstName")]
		public virtual string PrimaryContactFirstName { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactLastName")]
		public virtual string PrimaryContactLastName { get; private set; }

		[MaxLength(128)]
		[Column("primaryContactPhone")]
		public virtual string PrimaryContactPhone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>766a5877c286567eff2f3d0799ade5b8</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/