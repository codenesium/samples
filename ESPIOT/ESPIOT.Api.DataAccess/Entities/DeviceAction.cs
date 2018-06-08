using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace ESPIOTNS.Api.DataAccess
{
        [Table("DeviceAction", Schema="dbo")]
        public partial class DeviceAction: AbstractEntity
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

                [Column("deviceId", TypeName="int")]
                public int DeviceId { get; private set; }

                [Key]
                [Column("id", TypeName="int")]
                public int Id { get; private set; }

                [Column("name", TypeName="varchar(90)")]
                public string Name { get; private set; }

                [Column("value", TypeName="varchar(4000)")]
                public string @Value { get; private set; }

                [ForeignKey("DeviceId")]
                public virtual Device Device { get; set; }
        }
}

/*<Codenesium>
    <Hash>736bfd7622673d31cac270f5a41e33dc</Hash>
</Codenesium>*/