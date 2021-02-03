using System.Collections.Generic;
using System;
using INStudio.Data;


namespace INStudio.Services
{
    public interface IINMediaService
    {
        ICollection<INMedia> GetAll();
    }
}