using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ESPIOTNS.Api.DataAccess
{
        [Table("DeviceAction", Schema="dbo")]
        public partial class DeviceAction : AbstractEntity
        {
                public DeviceAction()
                {
                }

                public void SetProperties(
                        int deviceId,
                        int id,
                        string name,
                        string @value)
                {
                        this.DeviceId = deviceId;
                        this.Id = id;
                        this.Name = name;
                        this.@Value = @value;
                }

                [Column("deviceId")]
                public int DeviceId { get; private set; }

                [Key]
                [Column("id")]
                public int Id { get; private set; }

                [Column("name")]
                public string Name { get; private set; }

                [Column("value")]
                public string @Value { get; private set; }

                [ForeignKey("DeviceId")]
                public virtual Device Device { get; set; }
        }
}

/*<Codenesium>
    <Hash>1e8e7ff3c25c6835ef65e6aec6aa7975</Hash>
</Codenesium>*/