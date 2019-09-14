using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CADNS.Api.DataAccess
{
	[Table("Note", Schema="dbo")]
	public partial class Note : AbstractEntity
	{
		public Note()
		{
		}

		public virtual void SetProperties(
			int id,
			int callId,
			DateTime dateCreated,
			string noteText,
			int officerId)
		{
			this.Id = id;
			this.CallId = callId;
			this.DateCreated = dateCreated;
			this.NoteText = noteText;
			this.OfficerId = officerId;
		}

		[Column("callId")]
		public virtual int CallId { get; private set; }

		[Column("dateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(8000)]
		[Column("noteText")]
		public virtual string NoteText { get; private set; }

		[Column("officerId")]
		public virtual int OfficerId { get; private set; }

		[ForeignKey("CallId")]
		public virtual Call CallIdNavigation { get; private set; }

		public void SetCallIdNavigation(Call item)
		{
			this.CallIdNavigation = item;
		}

		[ForeignKey("OfficerId")]
		public virtual Officer OfficerIdNavigation { get; private set; }

		public void SetOfficerIdNavigation(Officer item)
		{
			this.OfficerIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>61f9aaaa9a67950b3ad05a4df7088bae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/