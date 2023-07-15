﻿using CongestionTaxCalculator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Application.Contracts
{
    public interface ICongestionTaxAppService
    {
        public Decimal GetTax(CongestionTaxRequestDto request);

    }
}
