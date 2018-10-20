using Codenesium.DataConversionExtensions;
using System;

namespace StudioResourceManagerNS.Api.Services
{
	public abstract class AbstractBOAdmin : AbstractBusinessObject
	{
		public AbstractBOAdmin()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  DateTime? birthday,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string phone,
		                                  int userId,
		                                  bool isDeleted)
		{
			this.Birthday = birthday;
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
			this.UserId = userId;
			this.IsDeleted = isDeleted;
		}

		public DateTime? Birthday { get; private set; }

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Phone { get; private set; }

		public int UserId { get; private set; }

		public bool IsDeleted { get; private set; }
	}
}

/*<Codenesium>
    <Hash>98a334127cecc2410be4531c6fce6341</Hash>
</Codenesium>*/