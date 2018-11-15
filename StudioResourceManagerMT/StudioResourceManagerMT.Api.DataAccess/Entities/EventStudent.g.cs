using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("EventStudent", Schema="dbo")]
	public partial class EventStudent : AbstractEntity
	{
		public EventStudent()
		{
		}

		public virtual void SetProperties(
			int eventId,
			int studentId)
		{
			this.EventId = eventId;
			this.StudentId = studentId;
		}

		[Key]
		[Column("eventId")]
		public virtual int EventId { get; private set; }

		[Key]
		[Column("studentId")]
		public virtual int StudentId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ccaa7a568f4c3ef78320c72f227d8aea</Hash>
</Codenesium>*/