using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class EmployeeModel
	{
		public EmployeeModel()
		{}

		public EmployeeModel(
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName.ToString();
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName.ToString();
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

		private bool isSalesPerson;

		[Required]
		public bool IsSalesPerson
		{
			get
			{
				return this.isSalesPerson;
			}

			set
			{
				this.isSalesPerson = value;
			}
		}

		private bool isShipper;

		[Required]
		public bool IsShipper
		{
			get
			{
				return this.isShipper;
			}

			set
			{
				this.isShipper = value;
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
	}
}

/*<Codenesium>
    <Hash>a16ecddbdadc023c3b4ec677ce375254</Hash>
</Codenesium>*/