using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkLogModel
	{
		public LinkLogModel()
		{}

		public LinkLogModel(DateTime dateEntered,
		                    int linkId,
		                    string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.LinkId = linkId.ToInt();
			this.Log = log;
		}

		public LinkLogModel(POCOLinkLog poco)
		{
			this.DateEntered = poco.DateEntered.ToDateTime();
			this.Log = poco.Log;

			this.LinkId = poco.LinkId.Value.ToInt();
		}

		private DateTime _dateEntered;
		[Required]
		public DateTime DateEntered
		{
			get
			{
				return _dateEntered;
			}
			set
			{
				this._dateEntered = value;
			}
		}

		private int _linkId;
		[Required]
		public int LinkId
		{
			get
			{
				return _linkId;
			}
			set
			{
				this._linkId = value;
			}
		}

		private string _log;
		[Required]
		public string Log
		{
			get
			{
				return _log;
			}
			set
			{
				this._log = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>174b2932b0b99c7d0c6cd49ad9db1200</Hash>
</Codenesium>*/