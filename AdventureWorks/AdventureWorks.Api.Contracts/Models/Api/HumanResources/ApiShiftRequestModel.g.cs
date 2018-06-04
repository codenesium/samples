using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiShiftRequestModel: AbstractApiRequestModel
	{
		public ApiShiftRequestModel() : base()
		{}

		public void SetProperties(
			TimeSpan endTime,
			DateTime modifiedDate,
			string name,
			TimeSpan startTime)
		{
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Name = name;
			this.StartTime = startTime;
		}

		private TimeSpan endTime;

		[Required]
		public TimeSpan EndTime
		{
			get
			{
				return this.endTime;
			}

			set
			{
				this.endTime = value;
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

		private TimeSpan startTime;

		[Required]
		public TimeSpan StartTime
		{
			get
			{
				return this.startTime;
			}

			set
			{
				this.startTime = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f65157aeffae4cdbee77e2bf1ddf2f15</Hash>
</Codenesium>*/