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

		public LinkLogModel(int linkId,
		                    string log,
		                    DateTime dateEntered)
		{
			this.LinkId = linkId.ToInt();
			this.Log = log;
			this.DateEntered = dateEntered.ToDateTime();
		}

		public LinkLogModel(POCOLinkLog poco)
		{
			this.Log = poco.Log;
			this.DateEntered = poco.DateEntered.ToDateTime();

			this.LinkId = poco.LinkId.Value.ToInt();
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
	}
}

/*<Codenesium>
    <Hash>0a2d1ce49cf24d322bede0f04b49e34c</Hash>
</Codenesium>*/