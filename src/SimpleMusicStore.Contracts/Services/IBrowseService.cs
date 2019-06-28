﻿using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IBrowseService
    {
        Browse GenerateBrowseView();
        IEnumerable<RecordDetails> Filter(FilterCriterias criterias);
        SearchResult Search(string searchTerm);
    }
}
