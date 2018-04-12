using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DepartmentModel
	{
		public DepartmentModel()
		{}

		public DepartmentModel(
			string name,
			string groupName,
			DateTime modifiedDate)
		{
			this.Name = name;
			this.GroupName = groupName;
			this.ModifiedDate = modifiedDate.ToDateTime();
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
	}
}

/*<Codenesium>
    <Hash>98766273a819f7e7bd6f58d57987b262</Hash>
</Codenesium>*/