using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstagroomEX.Contracts
{
    public interface IWorkWithPhotoService
    {
        Task<string> PickPhoto();
        Task<string> TakePhoto();

    }
}
