using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.Contracts
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
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Phone = phone;
			this.IsAdult = isAdult;
			this.Birthday = birthday;
			this.FamilyId = familyId.ToInt();
			this.StudioId = studioId.ToInt();
			this.SmsRemindersEnabled = smsRemindersEnabled;
			this.EmailRemindersEnabled = emailRemindersEnabled;
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
    <Hash>fa7d02369442e24c58b8007d9813b393</Hash>
</Codenesium>*/