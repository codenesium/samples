using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class ApiLinkLogRequestModel: AbstractApiRequestModel
	{
		public ApiLinkLogRequestModel() : base()
		{}

		public void SetProperties(
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
    <Hash>7dbd5698e6bc6955fefa4dff92ab9716</Hash>
</Codenesium>*/