using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace ESPIOTNS.Api.Contracts
{
	public partial class DeviceModel
	{
		public DeviceModel()
		{}

		public DeviceModel(int id,
		                   string name,
		                   Guid publicId)
		{
			this.Id = id.ToInt();
			this.Name = name;
			this.PublicId = publicId;
		}

		public DeviceModel(POCODevice poco)
		{
			this.Id = poco.Id.ToInt();
			this.Name = poco.Name;
			this.PublicId = poco.PublicId;
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

		private Guid _publicId;
		public Guid PublicId
		{
			get
			{
				return _publicId;
			}
			set
			{
				this._publicId = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>e7ca8f2b9e605449d89ab079ccb9c5ed</Hash>
</Codenesium>*/