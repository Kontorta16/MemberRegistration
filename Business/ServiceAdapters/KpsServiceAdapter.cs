﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.KpsServiceReference;
using Entities.Concrete;

namespace Business.ServiceAdapters
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool ValidateUser(Member member)
        {
            var client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcNo), member.FirstName.ToUpper(),
                member.LastName.ToUpper(), member.DateOfBirth.Year);

        }
    }
}
