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

		public LinkModel(string name,
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

		public LinkModel(POCOLink poco)
		{
			this.Name = poco.Name;
			this.DynamicParameters = poco.DynamicParameters;
			this.StaticParameters = poco.StaticParameters;
			this.Order = poco.Order.ToInt();
			this.DateStarted = poco.DateStarted.ToNullableDateTime();
			this.DateCompleted = poco.DateCompleted.ToNullableDateTime();
			this.Response = poco.Response;
			this.ExternalId = poco.ExternalId;

			this.ChainId = poco.ChainId.Value.ToInt();
			this.AssignedMachineId = poco.AssignedMachineId.Value.ToInt();
			this.LinkStatusId = poco.LinkStatusId.Value.ToInt();
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

		private string _dynamicParameters;
		public string DynamicParameters
		{
			get
			{
				return _dynamicParameters.IsEmptyOrZeroOrNull() ? null : _dynamicParameters;
			}
			set
			{
				this._dynamicParameters = value;
			}
		}

		private string _staticParameters;
		public string StaticParameters
		{
			get
			{
				return _staticParameters.IsEmptyOrZeroOrNull() ? null : _staticParameters;
			}
			set
			{
				this._staticParameters = value;
			}
		}

		private int _chainId;
		[Required]
		public int ChainId
		{
			get
			{
				return _chainId;
			}
			set
			{
				this._chainId = value;
			}
		}

		private Nullable<int> _assignedMachineId;
		public Nullable<int> AssignedMachineId
		{
			get
			{
				return _assignedMachineId.IsEmptyOrZeroOrNull() ? null : _assignedMachineId;
			}
			set
			{
				this._assignedMachineId = value;
			}
		}

		private int _linkStatusId;
		[Required]
		public int LinkStatusId
		{
			get
			{
				return _linkStatusId;
			}
			set
			{
				this._linkStatusId = value;
			}
		}

		private int _order;
		[Required]
		public int Order
		{
			get
			{
				return _order;
			}
			set
			{
				this._order = value;
			}
		}

		private Nullable<DateTime> _dateStarted;
		public Nullable<DateTime> DateStarted
		{
			get
			{
				return _dateStarted.IsEmptyOrZeroOrNull() ? null : _dateStarted;
			}
			set
			{
				this._dateStarted = value;
			}
		}

		private Nullable<DateTime> _dateCompleted;
		public Nullable<DateTime> DateCompleted
		{
			get
			{
				return _dateCompleted.IsEmptyOrZeroOrNull() ? null : _dateCompleted;
			}
			set
			{
				this._dateCompleted = value;
			}
		}

		private string _response;
		public string Response
		{
			get
			{
				return _response.IsEmptyOrZeroOrNull() ? null : _response;
			}
			set
			{
				this._response = value;
			}
		}

		private Guid _externalId;
		[Required]
		public Guid ExternalId
		{
			get
			{
				return _externalId;
			}
			set
			{
				this._externalId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>b08e8144ce49032d34a20665b7435e4a</Hash>
</Codenesium>*/