using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class DatabaseLogModel
	{
		public DatabaseLogModel()
		{}

		public DatabaseLogModel(
			DateTime postTime,
			string databaseUser,
			string @event,
			string schema,
			string @object,
			string tSQL,
			string xmlEvent)
		{
			this.PostTime = postTime.ToDateTime();
			this.DatabaseUser = databaseUser;
			this.@Event = @event;
			this.Schema = schema;
			this.@Object = @object;
			this.TSQL = tSQL;
			this.XmlEvent = xmlEvent;
		}

		private DateTime postTime;

		[Required]
		public DateTime PostTime
		{
			get
			{
				return this.postTime;
			}

			set
			{
				this.postTime = value;
			}
		}

		private string databaseUser;

		[Required]
		public string DatabaseUser
		{
			get
			{
				return this.databaseUser;
			}

			set
			{
				this.databaseUser = value;
			}
		}

		private string @event;

		[Required]
		public string @Event
		{
			get
			{
				return this.@event;
			}

			set
			{
				this.@event = value;
			}
		}

		private string schema;

		public string Schema
		{
			get
			{
				return this.schema.IsEmptyOrZeroOrNull() ? null : this.schema;
			}

			set
			{
				this.schema = value;
			}
		}

		private string @object;

		public string @Object
		{
			get
			{
				return this.@object.IsEmptyOrZeroOrNull() ? null : this.@object;
			}

			set
			{
				this.@object = value;
			}
		}

		private string tSQL;

		[Required]
		public string TSQL
		{
			get
			{
				return this.tSQL;
			}

			set
			{
				this.tSQL = value;
			}
		}

		private string xmlEvent;

		[Required]
		public string XmlEvent
		{
			get
			{
				return this.xmlEvent;
			}

			set
			{
				this.xmlEvent = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>54e4ec91cfcaa1669ea069854e51880b</Hash>
</Codenesium>*/