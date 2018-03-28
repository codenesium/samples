using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace NebulaNS.Api.Contracts
{
	public partial class MachineModel
	{
		public MachineModel()
		{}

		public MachineModel(string name,
		                    Guid machineGuid,
		                    string jwtKey,
		                    string lastIpAddress,
		                    string description)
		{
			this.Name = name;
			this.MachineGuid = machineGuid;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.Description = description;
		}

		public MachineModel(POCOMachine poco)
		{
			this.Name = poco.Name;
			this.MachineGuid = poco.MachineGuid;
			this.JwtKey = poco.JwtKey;
			this.LastIpAddress = poco.LastIpAddress;
			this.Description = poco.Description;
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

		private Guid _machineGuid;
		[Required]
		public Guid MachineGuid
		{
			get
			{
				return _machineGuid;
			}
			set
			{
				this._machineGuid = value;
			}
		}

		private string _jwtKey;
		[Required]
		public string JwtKey
		{
			get
			{
				return _jwtKey;
			}
			set
			{
				this._jwtKey = value;
			}
		}

		private string _lastIpAddress;
		[Required]
		public string LastIpAddress
		{
			get
			{
				return _lastIpAddress;
			}
			set
			{
				this._lastIpAddress = value;
			}
		}

		private string _description;
		[Required]
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				this._description = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>5d1d6db0f1aa9701c4416fc032511710</Hash>
</Codenesium>*/