using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDepartmentModel
	{
		public ApiDepartmentModel()
		{}

		public ApiDepartmentModel(
			string groupName,
			DateTime modifiedDate,
			string name)
		{
			this.GroupName = groupName.ToString();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name.ToString();
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
    <Hash>52874ada30dc5b6686edac2dcc7cfb38</Hash>
</Codenesium>*/