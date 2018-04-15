using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class EFStudent
	{
		public EFStudent()
		{}

		public void SetProperties(
			int id,
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled)
		{
			this.Id = id.ToInt();
			this.Email = email.ToString();
			this.FirstName = firstName.ToString();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.IsAdult = isAdult.ToBoolean();
			this.Birthday = birthday.ToDateTime();
			this.FamilyId = familyId.ToInt();
			this.StudioId = studioId.ToInt();
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("id", TypeName="int")]
		public int Id { get; set; }

		[Column("email", TypeName="varchar(128)")]
		public string Email { get; set; }

		[Column("firstName", TypeName="varchar(128)")]
		public string FirstName { get; set; }

		[Column("lastName", TypeName="varchar(128)")]
		public string LastName { get; set; }

		[Column("phone", TypeName="varchar(128)")]
		public string Phone { get; set; }

		[Column("isAdult", TypeName="bit")]
		public bool IsAdult { get; set; }

		[Column("birthday", TypeName="date")]
		public DateTime Birthday { get; set; }

		[Column("familyId", TypeName="int")]
		public int FamilyId { get; set; }

		[Column("studioId", TypeName="int")]
		public int StudioId { get; set; }

		[Column("smsRemindersEnabled", TypeName="bit")]
		public bool SmsRemindersEnabled { get; set; }

		[Column("emailRemindersEnabled", TypeName="bit")]
		public bool EmailRemindersEnabled { get; set; }

		[ForeignKey("FamilyId")]
		public virtual EFFamily Family { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>d7158ce0b178da10854ec2e8843e09da</Hash>
</Codenesium>*/