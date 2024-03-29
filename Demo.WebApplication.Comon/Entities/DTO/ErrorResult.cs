﻿using B1.Demo.WebApplication.Common.Enums;

namespace B1.Demo.WebApplication.Common.Entities.DTO
{
    public class ErrorResult
    {
        public ErrorCode ErrorCode { get; set; }

        public string DevMsg { get; set; }
        
        public string UserMsg { get; set; }

        public object MoreInfo { get; set; }

        public string TraceId { get; set; }

    }
}
