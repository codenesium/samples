using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace sample1NS.Api.Contracts
{
	public partial class MachineModel
	{
		public MachineModel()
		{}

		public MachineModel(string description,
		                    int id,
		                    string jwtKey,
		                    string lastIpAddress,
		                    Guid machineGuid,
		                    string name)
		{
			this.Description = description;
			this.Id = id.ToInt();
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid;
			this.Name = name;
		}

		public MachineModel(POCOMachine poco)
		{
			this.Description = poco.Description;
			this.Id = poco.Id.ToInt();
			this.JwtKey = poco.JwtKey;
			this.LastIpAddress = poco.LastIpAddress;
			this.MachineGuid = poco.MachineGuid;
			this.Name = poco.Name;
		}

		private string _description;
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

		private int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}

		private string _jwtKey;
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
    <Hash>3c19e07feee03f7942845ca8346f3957</Hash>
</Codenesium>*/