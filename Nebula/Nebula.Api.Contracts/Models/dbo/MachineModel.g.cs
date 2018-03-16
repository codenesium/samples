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

		public MachineModel(string description,
		                    string jwtKey,
		                    string lastIpAddress,
		                    Guid machineGuid,
		                    string name)
		{
			this.Description = description;
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		public MachineModel(POCOMachine poco)
		{
			this.Description = poco.Description;
			this.JwtKey = poco.JwtKey;
			this.LastIpAddress = poco.LastIpAddress;
			this.MachineGuid = poco.MachineGuid;
			this.Name = poco.Name;
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
	}
}

/*<Codenesium>
    <Hash>6e5949af17a80d3355280a2f4313661e</Hash>
</Codenesium>*/