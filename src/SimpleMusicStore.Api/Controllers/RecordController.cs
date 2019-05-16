﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.Binding;

namespace SimpleMusicStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _records;

        public RecordController(IRecordService records)
        {
            _records = records;
        }

        public async Task Add(NewRecord record)
        {
            //TODO in the front end, when someone paste discogs url, provide an preview with some AJAX, so the user could see what he is going to add to the store????
            await _records.Add(record);
        }


    }
}