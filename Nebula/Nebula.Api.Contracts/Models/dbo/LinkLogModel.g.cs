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

		public LinkLogModel(
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.LinkId = linkId.ToInt();
			this.Log = log.ToString();
		}

		private DateTime dateEntered;

		[Required]
		public DateTime DateEntered
		{
			get
			{
				return this.dateEntered;
			}

			set
			{
				this.dateEntered = value;
			}
		}

		private int linkId;

		[Required]
		public int LinkId
		{
			get
			{
				return this.linkId;
			}

			set
			{
				this.linkId = value;
			}
		}

		private string log;

		[Required]
		public string Log
		{
			get
			{
				return this.log;
			}

			set
			{
				this.log = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>c371e4ec8a2ea4bc5167b00e076abf5a</Hash>
</Codenesium>*/