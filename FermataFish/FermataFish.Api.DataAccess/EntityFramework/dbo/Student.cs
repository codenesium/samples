using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class Student: AbstractEntityFrameworkDTO
	{
		public Student()
		{}

		public void SetProperties(
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
			this.Birthday = birthday.ToDateTime();
			this.Email = email;
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
			this.FamilyId = familyId.ToInt();
			this.FirstName = firstName;
			this.Id = id.ToInt();
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName;
			this.Phone = phone;
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.StudioId = studioId.ToInt();
		}

		[Column("birthday", TypeName="date")]
		public DateTime Birthday { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("emailRemindersEnabled", TypeName="bit")]
		public bool EmailRemindersEnabled { get; set; }

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Key]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("isAdult", TypeName="bit")]
		public bool IsAdult { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; set; }

		[Column("smsRemindersEnabled", TypeName="bit")]
		public bool SmsRemindersEnabled { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[ForeignKey("FamilyId")]
		public virtual Family Family { get; set; }

		[ForeignKey("StudioId")]
		public virtual Studio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>6df97df8fe182a5d7ba1287aaf0b9f49</Hash>
</Codenesium>*/