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

		public MachineModel(
			string name,
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

		private Guid machineGuid;

		[Required]
		public Guid MachineGuid
		{
			get
			{
				return this.machineGuid;
			}

			set
			{
				this.machineGuid = value;
			}
		}

		private string jwtKey;

		[Required]
		public string JwtKey
		{
			get
			{
				return this.jwtKey;
			}

			set
			{
				this.jwtKey = value;
			}
		}

		private string lastIpAddress;

		[Required]
		public string LastIpAddress
		{
			get
			{
				return this.lastIpAddress;
			}

			set
			{
				this.lastIpAddress = value;
			}
		}

		private string description;

		[Required]
		public string Description
		{
			get
			{
				return this.description;
			}

			set
			{
				this.description = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>6476036825ba61c617c3075291f54875</Hash>
</Codenesium>*/