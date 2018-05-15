using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkLogModel
	{
		public ApiLinkLogModel()
		{}

		public ApiLinkLogModel(
			DateTime dateEntered,
			int linkId,
			string log)
		{
			this.DateEntered = dateEntered.ToDateTime();
			this.LinkId = linkId.ToInt();
			this.Log = log;
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
    <Hash>d6d92c1eb91f2816d7243e4715117698</Hash>
</Codenesium>*/