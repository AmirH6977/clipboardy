﻿using Assets.Model.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities {

    [Table("AccountDevice")]
    public partial class AccountDevice: BaseEntity {

        [Required]
        public int? AccountId { get; set; }

        [Required, MaxLength(128)]
        public string Token { get; set; }

        [Required, MaxLength(128)]
        public string DeviceId { get; set; }

        [Required, MaxLength(128)]
        public string DeviceName { get; set; }

        [Required, MaxLength(128)]
        public string DeviceType { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Status? StatusId { get; set; }
    }

    public partial class AccountDevice {
        //[ForeignKey(nameof(AccountId))]
        //public Account Account { get; set; }
    }
}
