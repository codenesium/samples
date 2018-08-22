using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class Student : AbstractEntity
	{
		public Student()
		{
		}

		public virtual void SetProperties(
			int id,
			DateTime birthday,
			string email,
			bool emailRemindersEnabled,
			int familyId,
			string firstName,
			bool isAdult,
			string lastName,
			string phone,
			bool smsRemindersEnabled,
			int studioId)
		{
			this.Id = id;
			this.Birthday = birthday;
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled;
			this.FamilyId = familyId;
			this.FirstName = firstName;
			this.IsAdult = isAdult;
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled;
			this.StudioId = studioId;
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id")]
		public int Id { get; private set; }

		[Column("birthday")]
		public DateTime Birthday { get; private set; }

		[MaxLength(128)]
		[Column("email")]
		public string Email { get; private set; }

		[Column("emailRemindersEnabled")]
		public bool EmailRemindersEnabled { get; private set; }

		[Column("familyId")]
		public int FamilyId { get; private set; }

		[MaxLength(128)]
		[Column("firstName")]
		public string FirstName { get; private set; }

		[Column("isAdult")]
		public bool IsAdult { get; private set; }

		[MaxLength(128)]
		[Column("lastName")]
		public string LastName { get; private set; }

		[MaxLength(128)]
		[Column("phone")]
		public string Phone { get; private set; }

		[Column("smsRemindersEnabled")]
		public bool SmsRemindersEnabled { get; private set; }

		[Column("studioId")]
		public int StudioId { get; private set; }

		[ForeignKey("FamilyId")]
		public virtual Family FamilyNavigation { get; private set; }

		[ForeignKey("StudioId")]
		public virtual Studio StudioNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5bcec5230b1204ac6e61a7bd21b05ba8</Hash>
</Codenesium>*/