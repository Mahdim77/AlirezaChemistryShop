using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomFramework.Presentation
{
    public interface IFileUploader
    {
        string Upload(IFormFile file,string folder,string basefolder);
    }
}
