using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace FermataFishNS.Api.DataAccess
{
	[Table("Student", Schema="dbo")]
	public partial class EFStudent: AbstractEntityFrameworkPOCO
	{
		public EFStudent()
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
			this.Email = email.ToString();
			this.EmailRemindersEnabled = emailRemindersEnabled.ToBoolean();
			this.FamilyId = familyId.ToInt();
			this.FirstName = firstName.ToString();
			this.Id = id.ToInt();
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
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
		public virtual EFFamily Family { get; set; }

		[ForeignKey("StudioId")]
		public virtual EFStudio Studio { get; set; }
	}
}

/*<Codenesium>
    <Hash>f99fdf5fc24744244bc0ee6fc131ac86</Hash>
</Codenesium>*/