using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StackOverflowNS.Api.DataAccess
{
	[Table("Badges", Schema="dbo")]
	public partial class Badges : AbstractEntity
	{
		public Badges()
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
		public DateTime Date { get; private set; }

		[Key]
		[Column("Id")]
		public int Id { get; private set; }

		[Column("Name")]
		public string Name { get; private set; }

		[Column("UserId")]
		public int UserId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>49184f22e202e67a67dc8ba80aec8684</Hash>
</Codenesium>*/