using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class LinkModel
	{
		public LinkModel()
		{}

		public LinkModel(
			string name,
			string dynamicParameters,
			string staticParameters,
			int chainId,
			Nullable<int> assignedMachineId,
			int linkStatusId,
			int order,
			Nullable<DateTime> dateStarted,
			Nullable<DateTime> dateCompleted,
			string response,
			Guid externalId)
		{
			this.Name = name;
			this.DynamicParameters = dynamicParameters;
			this.StaticParameters = staticParameters;
			this.ChainId = chainId.ToInt();
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Order = order.ToInt();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.Response = response;
			this.ExternalId = externalId;
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

		private string dynamicParameters;

		public string DynamicParameters
		{
			get
			{
				return this.dynamicParameters.IsEmptyOrZeroOrNull() ? null : this.dynamicParameters;
			}

			set
			{
				this.dynamicParameters = value;
			}
		}

		private string staticParameters;

		public string StaticParameters
		{
			get
			{
				return this.staticParameters.IsEmptyOrZeroOrNull() ? null : this.staticParameters;
			}

			set
			{
				this.staticParameters = value;
			}
		}

		private int chainId;

		[Required]
		public int ChainId
		{
			get
			{
				return this.chainId;
			}

			set
			{
				this.chainId = value;
			}
		}

		private Nullable<int> assignedMachineId;

		public Nullable<int> AssignedMachineId
		{
			get
			{
				return this.assignedMachineId.IsEmptyOrZeroOrNull() ? null : this.assignedMachineId;
			}

			set
			{
				this.assignedMachineId = value;
			}
		}

		private int linkStatusId;

		[Required]
		public int LinkStatusId
		{
			get
			{
				return this.linkStatusId;
			}

			set
			{
				this.linkStatusId = value;
			}
		}

		private int order;

		[Required]
		public int Order
		{
			get
			{
				return this.order;
			}

			set
			{
				this.order = value;
			}
		}

		private Nullable<DateTime> dateStarted;

		public Nullable<DateTime> DateStarted
		{
			get
			{
				return this.dateStarted.IsEmptyOrZeroOrNull() ? null : this.dateStarted;
			}

			set
			{
				this.dateStarted = value;
			}
		}

		private Nullable<DateTime> dateCompleted;

		public Nullable<DateTime> DateCompleted
		{
			get
			{
				return this.dateCompleted.IsEmptyOrZeroOrNull() ? null : this.dateCompleted;
			}

			set
			{
				this.dateCompleted = value;
			}
		}

		private string response;

		public string Response
		{
			get
			{
				return this.response.IsEmptyOrZeroOrNull() ? null : this.response;
			}

			set
			{
				this.response = value;
			}
		}

		private Guid externalId;

		[Required]
		public Guid ExternalId
		{
			get
			{
				return this.externalId;
			}

			set
			{
				this.externalId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f43a0548521270f03576931c0abcd22f</Hash>
</Codenesium>*/