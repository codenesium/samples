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
		public virtual Users UserIdNavigation { get; private set; }

		public void SetUserIdNavigation(Users item)
		{
			this.UserIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>0fbe9d6829f3be8ba6d04c6d9e9ce16e</Hash>
</Codenesium>*/