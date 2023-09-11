﻿using System.Xml.Linq;
using WGBudget.Entities.Interfaces.Common;
using RecordType = WGBudget.Entities.Data.Transaction;

namespace WGBudget.Entities.Interfaces.Transaction
{
    public interface IRetrieveTransaction : IRetrieveRecord<RecordType, int>
    {
    }
}
