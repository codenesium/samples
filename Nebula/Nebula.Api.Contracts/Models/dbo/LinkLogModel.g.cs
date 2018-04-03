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
    <Hash>58f24bfa6e99f52ac1e430fe21738cd5</Hash>
</Codenesium>*/