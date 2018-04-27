using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace FermataFishNS.Api.Contracts
{
	public partial class StudentModel
	{
		public StudentModel()
		{}

		public StudentModel(
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
			this.IsAdult = isAdult.ToBoolean();
			this.LastName = lastName.ToString();
			this.Phone = phone.ToString();
			this.SmsRemindersEnabled = smsRemindersEnabled.ToBoolean();
			this.StudioId = studioId.ToInt();
		}

		private DateTime birthday;

		[Required]
		public DateTime Birthday
		{
			get
			{
				return this.birthday;
			}

			set
			{
				this.birthday = value;
			}
		}

		private string email;

		[Required]
		public string Email
		{
			get
			{
				return this.email;
			}

			set
			{
				this.email = value;
			}
		}

		private bool emailRemindersEnabled;

		[Required]
		public bool EmailRemindersEnabled
		{
			get
			{
				return this.emailRemindersEnabled;
			}

			set
			{
				this.emailRemindersEnabled = value;
			}
		}

		private int familyId;

		[Required]
		public int FamilyId
		{
			get
			{
				return this.familyId;
			}

			set
			{
				this.familyId = value;
			}
		}

		private string firstName;

		[Required]
		public string FirstName
		{
			get
			{
				return this.firstName;
			}

			set
			{
				this.firstName = value;
			}
		}

		private bool isAdult;

		[Required]
		public bool IsAdult
		{
			get
			{
				return this.isAdult;
			}

			set
			{
				this.isAdult = value;
			}
		}

		private string lastName;

		[Required]
		public string LastName
		{
			get
			{
				return this.lastName;
			}

			set
			{
				this.lastName = value;
			}
		}

		private string phone;

		[Required]
		public string Phone
		{
			get
			{
				return this.phone;
			}

			set
			{
				this.phone = value;
			}
		}

		private bool smsRemindersEnabled;

		[Required]
		public bool SmsRemindersEnabled
		{
			get
			{
				return this.smsRemindersEnabled;
			}

			set
			{
				this.smsRemindersEnabled = value;
			}
		}

		private int studioId;

		[Required]
		public int StudioId
		{
			get
			{
				return this.studioId;
			}

			set
			{
				this.studioId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>8598df9e2b3a9f8fa957332faabeab9e</Hash>
</Codenesium>*/