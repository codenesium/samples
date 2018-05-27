using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiEmployeeRequestModel: AbstractApiRequestModel
	{
		public ApiEmployeeRequestModel() : base()
		{}

		public void SetProperties(
			string firstName,
			bool isSalesPerson,
			bool isShipper,
			string lastName)
		{
			this.FirstName = firstName;
			this.IsSalesPerson = isSalesPerson.ToBoolean();
			this.IsShipper = isShipper.ToBoolean();
			this.LastName = lastName;
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
    <Hash>914ce49f0ac373e9ee8ffe6d91a18d3b</Hash>
</Codenesium>*/