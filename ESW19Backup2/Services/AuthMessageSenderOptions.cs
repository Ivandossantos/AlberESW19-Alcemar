using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESW19Backup2.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }

        public AuthMessageSenderOptions()
        {
            SendGridUser = "Group5Email";
            SendGridKey = "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";
        }
    }
}