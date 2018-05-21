using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiDepartmentModel: AbstractModel
	{
		public ApiDepartmentModel() : base()
		{}

		public ApiDepartmentModel(
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
    <Hash>30e116a7e878b8a00fb62a2aa2c01c6a</Hash>
</Codenesium>*/