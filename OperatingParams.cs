using ImageMagick;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heic2Whatever
{
    public class OperatingParams
    {
        public MagickFormat Format { get; set; }
        public string Extension { get; set; }

        public bool OverwriteExistingFiles { get; set; }

    }
}

