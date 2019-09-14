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
			int id,
			DateTime date,
			string name,
			int userId)
		{
			this.Id = id;
			this.Date = date;
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

		[ForeignKey("UserId")]
		public virtual User UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(User item)
		{
			this.UserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>f090584fb9775572b22aceae5a67b0c1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/