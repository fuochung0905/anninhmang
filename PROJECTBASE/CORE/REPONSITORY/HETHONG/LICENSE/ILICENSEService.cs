using MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPONSITORY.HETHONG.LICENSE
{
    public interface ILICENSEService
    {
        BaseResponse<string> GetCodeRegister();
    }
}
