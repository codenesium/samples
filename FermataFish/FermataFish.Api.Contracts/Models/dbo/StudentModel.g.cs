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
	}
}

/*<Codenesium>
    <Hash>ee4fcd3dccd0570beb43b65d8fb5223f</Hash>
</Codenesium>*/