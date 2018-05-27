using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDepartmentRequestModel: AbstractApiRequestModel
	{
		public ApiDepartmentRequestModel() : base()
		{}

		public void SetProperties(
			string groupName,
			DateTime modifiedDate,
			string name)
		{
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
		}

		private string groupName;

		[Required]
		public string GroupName
		{
			get
			{
				return this.groupName;
			}

			set
			{
				this.groupName = value;
			}
		}

		private DateTime modifiedDate;

		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return this.modifiedDate;
			}

			set
			{
				this.modifiedDate = value;
			}
		}

		private string name;

		[Required]
		public string Name
		{
			get
			{
				return this.name;
			}

			set
			{
				this.name = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e080403d114282891bae92172b2d0f88</Hash>
</Codenesium>*/