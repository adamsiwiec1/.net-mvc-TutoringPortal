using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Models.MajorModel
{
    public interface IMajorRepo
    {
        List<Major> ListAllMajors();

        void AddMajor(Major major);
        Major FindMajor(int? majorID);
        void EditMajor(Major major);
        void DeleteMajor(Major major);
    }
}
