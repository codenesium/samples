using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace StudioResourceManagerMTNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class Student : AbstractEntity
	{
		public Student()
		{
		}

		public virtual void SetProperties(
			DateTime birthday,
			string email,
			bool emailRemindersEnabled,
			int familyId,
			string firstName,
			int id,
			bool isAdult,
			string lastName,
			string phone,
			bool smsRemindersEnabled,
			int userId)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled;
			this.FamilyId = familyId;
			this.FirstName = firstName;
			this.Id = id;
			this.IsAdult = isAdult;
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled;
			this.UserId = userId;
		}

		[Column("birthday")]
		public virtual DateTime Birthday { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public virtual string Email { get; private set; }

		[Column("emailRemindersEnabled")]
		public virtual bool EmailRemindersEnabled { get; private set; }

		[Column("familyId")]
		public virtual int FamilyId { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public virtual string FirstName { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[Column("isAdult")]
		public virtual bool IsAdult { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public virtual string LastName { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public virtual string Phone { get; private set; }

		[Column("smsRemindersEnabled")]
		public virtual bool SmsRemindersEnabled { get; private set; }

		[Column("userId")]
		public virtual int UserId { get; private set; }

		[ForeignKey("FamilyId")]
		public virtual Family FamilyNavigation { get; private set; }

		public void SetFamilyNavigation(Family item)
		{
			this.FamilyNavigation = item;
		}

		[ForeignKey("UserId")]
		public virtual User UserNavigation { get; private set; }

		public void SetUserNavigation(User item)
		{
			this.UserNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d9eb7b5672a98a85487387a3e0dcbc57</Hash>
</Codenesium>*/