using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ShiftModel
	{
		public ShiftModel()
		{}
		public ShiftModel(string name,
		                  TimeSpan startTime,
		                  TimeSpan endTime,
		                  DateTime modifiedDate)
		{
			this.Name = name;
			this.StartTime = startTime;
			this.EndTime = endTime;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		private string _name;
		[Required]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				this._name = value;
			}
		}

		private TimeSpan _startTime;
		[Required]
		public TimeSpan StartTime
		{
			get
			{
				return _startTime;
			}
			set
			{
				this._startTime = value;
			}
		}

		private TimeSpan _endTime;
		[Required]
		public TimeSpan EndTime
		{
			get
			{
				return _endTime;
			}
			set
			{
				this._endTime = value;
			}
		}

		private DateTime _modifiedDate;
		[Required]
		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}
			set
			{
				this._modifiedDate = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>020dc102ff643bca7ead772b35a13d8d</Hash>
</Codenesium>*/