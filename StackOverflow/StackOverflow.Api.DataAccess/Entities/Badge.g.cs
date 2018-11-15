using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Badges", Schema="dbo")]
	public partial class Badge : AbstractEntity
	{
		public Badge()
		{
		}

		public virtual void SetProperties(
			DateTime date,
			int id,
			string name,
			int userId)
		{
			this.Date = date;
			this.Id = id;
			this.Name = name;
			this.UserId = userId;
		}

		[Column("Date")]
		public virtual DateTime Date { get; private set; }

		[Key]
		[Column("Id")]
		public virtual int Id { get; private set; }

		[MaxLength(40)]
		[Column("Name")]
		public virtual string Name { get; private set; }

		[Column("UserId")]
		public virtual int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>73c6f337cace06472f0f2ac936c2043d</Hash>
</Codenesium>*/